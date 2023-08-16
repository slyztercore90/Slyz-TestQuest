//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002423
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

[QuestScript(91167)]
public class Quest91167Script : QuestScript
{
	protected override void Load()
	{
		SetId(91167);
		SetName("QUEST_LV_0500_20230130_002423");
		SetDescription("QUEST_LV_0500_20230130_002494");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY1_3_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_2"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("kill0", "Kill 10 Vubbe Chaser(s)", new KillObjective(59779, 10));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 125217));

		AddDialogHook("EP15_1_FABBEY1_AD1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_3_DLG1", "EP15_1_F_ABBEY1_3", "QUEST_LV_0500_20230130_002424", "QUEST_LV_0500_20230130_002425"))
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
}

