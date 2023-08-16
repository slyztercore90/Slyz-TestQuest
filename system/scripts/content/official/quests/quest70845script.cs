//--- Melia Script -----------------------------------------------------------
// Trees of the Royal Family
//--- Description -----------------------------------------------------------
// Quest to Talk to Indraja.
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

[QuestScript(70845)]
public class Quest70845Script : QuestScript
{
	protected override void Load()
	{
		SetId(70845);
		SetName("Trees of the Royal Family");
		SetDescription("Talk to Indraja");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ05"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15181));

		AddDialogHook("WHITETREES233_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES233_SQ_06_start", "WHITETREES23_3_SQ06", "Say that it isn't too difficult", "Say that the task is too abstract"))
			{
				case 1:
					await dialog.Msg("WHITETREES233_SQ_06_agree");
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
			await dialog.Msg("WHITETREES233_SQ_06_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

