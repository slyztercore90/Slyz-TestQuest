//--- Melia Script -----------------------------------------------------------
// Narvas Temple's Barrier (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Aistis.
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

[QuestScript(50340)]
public class Quest50340Script : QuestScript
{
	protected override void Load()
	{
		SetId(50340);
		SetName("Narvas Temple's Barrier (6)");
		SetDescription("Talk to Monk Aistis");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "WTREES22_3_SQ6_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(351));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_3_SQ5"));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 17901));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_3_SUBQ1_NPC5", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_3_SUBQ1_NPC5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_3_SUBQ6_START1", "WTREES22_3_SQ6", "Turn off the defensive system! Hurry!", "We need to find another way"))
		{
			case 1:
				await dialog.Msg("WTREES22_3_SUBQ6_AGG1");
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

		await dialog.Msg("WTREES22_3_SUBQ6_SUCC1");
		await dialog.Msg("BalloonText/WTREES22_3_SUBQ6_INFOR1/7");
		await dialog.Msg("FadeOutIN/1000");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

