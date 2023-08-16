//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002456
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

[QuestScript(91181)]
public class Quest91181Script : QuestScript
{
	protected override void Load()
	{
		SetId(91181);
		SetName("QUEST_LV_0500_20230130_002456");
		SetDescription("QUEST_LV_0500_20230130_002494");
		SetTrack("SPossible", "ESuccess", "EP15_1_F_ABBEY2_8_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_7"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP15_1_F_ABBEY2_8_DLG4");
			await dialog.Msg("FadeOutIN/2000");
			dialog.HideNPC("EP15_1_FABBEY2_AD2");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

