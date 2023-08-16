//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002426
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

[QuestScript(91168)]
public class Quest91168Script : QuestScript
{
	protected override void Load()
	{
		SetId(91168);
		SetName("QUEST_LV_0500_20230130_002426");
		SetDescription("QUEST_LV_0500_20230130_002494");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_3"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD3", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_4_DLG1", "EP15_1_F_ABBEY1_4", "QUEST_LV_0500_20230130_002427", "QUEST_LV_0500_20230130_002429", "QUEST_LV_0500_20230130_002428"))
			{
				case 1:
					await dialog.Msg("EP15_1_F_ABBEY1_4_DLG3");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("EP15_1_F_ABBEY1_4_DLG2");
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
			if (character.Inventory.HasItem("EP15_1_FABBEY1_MQ_4_ITEM1", 8))
			{
				character.Inventory.RemoveItem("EP15_1_FABBEY1_MQ_4_ITEM1", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP15_1_F_ABBEY1_4_DLG5");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY1_5");
	}
}

