//--- Melia Script -----------------------------------------------------------
// All-out War
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91118)]
public class Quest91118Script : QuestScript
{
	protected override void Load()
	{
		SetId(91118);
		SetName("All-out War");
		SetDescription("Talk to General Ramin");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "EP14_1_FCASTLE5_MQ_2_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(468));
		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_1"));

		AddReward(new ExpReward(1046153856, 1046153856));

		AddDialogHook("EP14_1_FCASTLE5_MQ_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("EP14_1_FCASTLE5_MQ_2_SNPC_DLG1", "EP14_1_FCASTLE5_MQ_2", "I'll be in my position", "I'm not ready yet"))
		{
			case 1:
				await dialog.Msg("EP14_1_FCASTLE5_MQ_2_SNPC_DLG2");
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

		dialog.HideNPC("EP14_1_FCASTLE5_MQ_1_NPC1");
		dialog.HideNPC("EP14_1_FCASTLE5_MQ_1_NPC2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}

	public override void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_1_FCASTLE5_MQ_3");
	}
}

