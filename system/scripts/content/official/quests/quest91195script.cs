//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002482
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002613.
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

[QuestScript(91195)]
public class Quest91195Script : QuestScript
{
	protected override void Load()
	{
		SetId(91195);
		SetName("QUEST_LV_0500_20230130_002482");
		SetDescription("QUEST_LV_0500_20230130_002613");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_6"));
		AddPrerequisite(new LevelPrerequisite(489));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_F_ABBEY_3_SQ1_BOOK1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_F_ABBEY_3_SQ1_BOOK2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_ABBEY3_SQ1_DLG1", "EP15_1_F_ABBEY_3_SQ1", "QUEST_LV_0500_20230130_002483", "QUEST_LV_0500_20230130_002484"))
			{
				case 1:
					// Func/SCR_EP15_1_FABBEY_3_SQ1_scroll_1_RUN;
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
			// Func/SCR_EP15_1_FABBEY_3_SQ1_scroll_2_RUN;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

