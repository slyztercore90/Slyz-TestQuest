//--- Melia Script -----------------------------------------------------------
// Restoring Lucienne's Honor (2)
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

[QuestScript(50296)]
public class Quest50296Script : QuestScript
{
	protected override void Load()
	{
		SetId(50296);
		SetName("Restoring Lucienne's Honor (2)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD343_HQ1"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddReward(new ItemReward("Gacha_H_008", 1));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_3_SQ_NPC_4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD343_HQ2_start1", "ORCHARD343_HQ2", "I'll deliver the news to Gatre.", "Please ask someone else."))
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
			await dialog.Msg("ORCHARD343_HQ2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

