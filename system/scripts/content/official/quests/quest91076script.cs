//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (5)
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

[QuestScript(91076)]
public class Quest91076Script : QuestScript
{
	protected override void Load()
	{
		SetId(91076);
		SetName("Chasing the Preacher (5)");
		SetDescription("Chase the Beholder");
		SetTrack("SPossible", "ESuccess", "EP13_2_DPRISON1_MQ_5_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddObjective("kill0", "Kill 1 Useless Abomination", new KillObjective(59674, 1));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_5", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

