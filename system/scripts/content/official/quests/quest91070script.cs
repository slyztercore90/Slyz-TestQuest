//--- Melia Script -----------------------------------------------------------
// Death as a Human (1)
//--- Description -----------------------------------------------------------
// Quest to Go to the Central Surveillance Area.
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

[QuestScript(91070)]
public class Quest91070Script : QuestScript
{
	protected override void Load()
	{
		SetId(91070);
		SetName("Death as a Human (1)");
		SetDescription("Go to the Central Surveillance Area");
		SetTrack("SPossible", "ESuccess", "EP13_2_DPRISON3_MQ_7_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddObjective("kill0", "Kill 1 Lunatic Marnox", new KillObjective(59658, 1));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_4", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_5", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("BalloonText/EP13_2_DPRISON3_MQ_7_DLG1/5");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

