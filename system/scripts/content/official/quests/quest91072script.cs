//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (1)
//--- Description -----------------------------------------------------------
// Quest to Chase the Beholder.
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

[QuestScript(91072)]
public class Quest91072Script : QuestScript
{
	protected override void Load()
	{
		SetId(91072);
		SetName("Chasing the Preacher (1)");
		SetDescription("Chase the Beholder");
		SetTrack("SPossible", "ESuccess", "EP13_2_DPRISON1_MQ_1_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("EP13_2_DPRISON1_MQ_NPC_1");
			dialog.HideNPC("EP13_2_DPRISON3_MQ_NPC_6");
			// Func/SCR_EP13_2_DPRISON3_TRAP_ALLHIDE;
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

