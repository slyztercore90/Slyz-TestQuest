//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002443
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002520.
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

[QuestScript(91176)]
public class Quest91176Script : QuestScript
{
	protected override void Load()
	{
		SetId(91176);
		SetName("QUEST_LV_0500_20230130_002443");
		SetDescription("QUEST_LV_0500_20230130_002520");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY2_3_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_2"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddObjective("kill0", "Kill 8 Vubbe Warrior(s) or Vubbe Rider(s)", new KillObjective(8, 59780, 59777));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY2_3_DLG1", "EP15_1_F_ABBEY2_3", "QUEST_LV_0500_20230130_002444", "QUEST_LV_0500_20230130_002445"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("EP15_1_F_ABBEY2_3_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_4");
	}
}

