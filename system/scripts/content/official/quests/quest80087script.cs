//--- Melia Script -----------------------------------------------------------
// Removing Tree Vines (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80087)]
public class Quest80087Script : QuestScript
{
	protected override void Load()
	{
		SetId(80087);
		SetName("Removing Tree Vines (2)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_9"));
		AddPrerequisite(new LevelPrerequisite(229));

		AddReward(new ExpReward(1082046, 1082046));
		AddReward(new ItemReward("expCard11", 4));
		AddReward(new ItemReward("Vis", 8244));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_3_MONK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY_35_3_SQ_10_start", "ABBEY_35_3_SQ_10", "I will try using it", "It is unstable at the moment"))
			{
				case 1:
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
			await dialog.Msg("ABBEY_35_3_SQ_10_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

