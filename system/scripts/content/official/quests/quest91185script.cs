//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002462
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002494.
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

[QuestScript(91185)]
public class Quest91185Script : QuestScript
{
	protected override void Load()
	{
		SetId(91185);
		SetName("QUEST_LV_0500_20230130_002462");
		SetDescription("QUEST_LV_0500_20230130_002494");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY_3_4_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_3"));
		AddPrerequisite(new LevelPrerequisite(487));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("AD3_FOLLOWNPC_CHAT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY_3_4_DLG1", "EP15_1_F_ABBEY_3_4", "Alright", "QUEST_LV_0500_20230130_002463"))
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
		character.Quests.Start("EP15_1_F_ABBEY_3_5");
	}
}

