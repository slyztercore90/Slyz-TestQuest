//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002457
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002554.
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

[QuestScript(91182)]
public class Quest91182Script : QuestScript
{
	protected override void Load()
	{
		SetId(91182);
		SetName("QUEST_LV_0500_20230130_002457");
		SetDescription("QUEST_LV_0500_20230130_002554");
		SetTrack("SPossible", "ESuccess", "EP15_1_F_ABBEY3_1_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_8"));
		AddPrerequisite(new LevelPrerequisite(487));

		AddObjective("kill0", "Kill 6 Vubbe Warrior(s) or Vubbe Shaman(s)", new KillObjective(6, 59780, 59778));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_F_ABBEY3_1_TRIGGER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

