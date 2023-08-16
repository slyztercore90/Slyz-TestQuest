//--- Melia Script -----------------------------------------------------------
// Stop the Beholder (2)
//--- Description -----------------------------------------------------------
// Quest to Stop Beholder.
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

[QuestScript(91160)]
public class Quest91160Script : QuestScript
{
	protected override void Load()
	{
		SetId(91160);
		SetName("Stop the Beholder (2)");
		SetDescription("Stop Beholder");
		SetTrack("SPossible", "ESuccess", "EP14_2_DCASTLE3_MQ_6_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_5"));
		AddPrerequisite(new LevelPrerequisite(478));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_DCASTLE3_RAMIN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			await dialog.Msg("EP14_2_DCASTLE3_MQ_6_DLG1");
			dialog.UnHideNPC("RAID_CASTLE_EP14_2_PORTAL");
			dialog.UnHideNPC("RAID_CASTLE_EP14_2_SOLD");
			// Func/EP14_2_END_MOVE_ZONE;
			dialog.HideNPC("EP14_2_DCASTLE3_RAMIN2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

