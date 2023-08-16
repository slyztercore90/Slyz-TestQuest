//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (2)
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

[QuestScript(91073)]
public class Quest91073Script : QuestScript
{
	protected override void Load()
	{
		SetId(91073);
		SetName("Chasing the Preacher (2)");
		SetDescription("Chase the Beholder");
		SetTrack("SPossible", "ESuccess", "EP13_2_DPRISON1_MQ_2_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddObjective("kill0", "Kill 20 Vubbe Guard(s)", new KillObjective(59665, 20));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

