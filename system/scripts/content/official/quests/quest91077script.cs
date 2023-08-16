//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (6)
//--- Description -----------------------------------------------------------
// Quest to Chasing Beholder.
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

[QuestScript(91077)]
public class Quest91077Script : QuestScript
{
	protected override void Load()
	{
		SetId(91077);
		SetName("Chasing the Preacher (6)");
		SetDescription("Chasing Beholder");
		SetTrack("SPossible", "ESuccess", "EP13_2_DPRISON1_MQ_6_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_5"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_6", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

