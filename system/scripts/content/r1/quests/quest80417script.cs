//--- Melia Script -----------------------------------------------------------
// Medeina's Traces (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Astra.
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

[QuestScript(80417)]
public class Quest80417Script : QuestScript
{
	protected override void Load()
	{
		SetId(80417);
		SetName("Medeina's Traces (5)");
		SetDescription("Talk to Kupole Astra");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_MAPLE_24_3_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(408));
		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_3_MQ_09"));

		AddObjective("kill0", "Kill 1 Demon Lord Tantalizer", new KillObjective(1, MonsterId.Boss_Tantaliser_Q1));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));
		AddReward(new ItemReward("Vis", 23256));

		AddDialogHook("F_MAPLE_243_MQ_10_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_243_MQ_11_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_MAPLE_24_3_MQ_10_ST", "F_MAPLE_24_3_MQ_10", "Let's go, then.", "Wait, we should think about it."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("F_MAPLE_24_3_MQ_10_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

