//--- Melia Script -----------------------------------------------------------
// Complicated Preparations(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
//---------------------------------------------------------------------------

using System.Threading.Tasks;
using Melia.Zone.Scripting;
using Melia.Zone.Scripting.Dialogues;
using Melia.Zone.World.Actors.Characters;
using Melia.Zone.World.Quests;
using Melia.Zone.World.Quests.Objectives;
using Melia.Zone.World.Quests.Prerequisites;
using Melia.Zone.World.Quests.Rewards;
using Melia.Shared.Tos.Const;

[QuestScript(70806)]
public class Quest70806Script : QuestScript
{
	protected override void Load()
	{
		SetId(70806);
		SetName("Complicated Preparations(2)");
		SetDescription("Talk to Vilhelmas");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ06"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES231_SQ_07_start", "WHITETREES23_1_SQ07", "Follow me.", "Say that you will be fine on your own"))
			{
				case 1:
					await dialog.Msg("WHITETREES231_SQ_07_agree");
					// Func/SCR_WHITETREES231_SQ_07_F;
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("WHITETREES231_SQ_07_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

