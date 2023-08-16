//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002438
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

[QuestScript(91173)]
public class Quest91173Script : QuestScript
{
	protected override void Load()
	{
		SetId(91173);
		SetName("QUEST_LV_0500_20230130_002438");
		SetDescription("QUEST_LV_0500_20230130_002494");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_8"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD4", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_9_DLG1", "EP15_1_F_ABBEY1_9", "QUEST_LV_0500_20230130_002439", "QUEST_LV_0500_20230130_002440"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("EP15_1_F_ABBEY1_9_DLG4");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			await dialog.Msg("FadeOutIN/2000");
			dialog.HideNPC("EP15_1_FABBEY1_AD4");
			dialog.HideNPC("EP15_1_FABBEY1_ROZE4");
			dialog.UnHideNPC("EP15_1_FABBEY2_ROZE1");
			dialog.UnHideNPC("EP15_1_FABBEY2_AD1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

