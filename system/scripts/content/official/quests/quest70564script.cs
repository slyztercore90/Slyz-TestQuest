//--- Melia Script -----------------------------------------------------------
// To the Pilgrim Camp
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Stella.
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

[QuestScript(70564)]
public class Quest70564Script : QuestScript
{
	protected override void Load()
	{
		SetId(70564);
		SetName("To the Pilgrim Camp");
		SetDescription("Talk to Monk Stella");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_3_SQ04"));
		AddPrerequisite(new LevelPrerequisite(268));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10988));

		AddDialogHook("PILGRIM413_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM413_SQ_06", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM413_SQ_05_start", "PILGRIM41_3_SQ05", "Let's hurry", "Say that you should have more detailed plans"))
			{
				case 1:
					await dialog.Msg("PILGRIM413_SQ_05_agree");
					// Func/SCR_PILGRIM413_SQ_05_P;
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
			await dialog.Msg("PILGRIM413_SQ_05_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

