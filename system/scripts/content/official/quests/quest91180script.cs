//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002453
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002511.
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

[QuestScript(91180)]
public class Quest91180Script : QuestScript
{
	protected override void Load()
	{
		SetId(91180);
		SetName("QUEST_LV_0500_20230130_002453");
		SetDescription("QUEST_LV_0500_20230130_002511");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY2_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_6"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddObjective("kill0", "Kill 1 Black Devilglove", new KillObjective(59770, 1));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY2_7_DLG1", "EP15_1_F_ABBEY2_7", "QUEST_LV_0500_20230130_002454", "QUEST_LV_0500_20230130_002455"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_8");
	}
}

