//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002431
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002502.
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

[QuestScript(91170)]
public class Quest91170Script : QuestScript
{
	protected override void Load()
	{
		SetId(91170);
		SetName("QUEST_LV_0500_20230130_002431");
		SetDescription("QUEST_LV_0500_20230130_002502");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_5"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("collect0", "Collect 10 Pokubu Meat(s)", new CollectItemObjective("EP15_1_FABBEY1_MQ_6_ITEM1", 10));
		AddDrop("EP15_1_FABBEY1_MQ_6_ITEM1", 6f, "ep15_1_Pokubu_ferocious");

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD2", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_6_DLG1", "EP15_1_F_ABBEY1_6", "QUEST_LV_0500_20230130_002432", "I have other obligations."))
			{
				case 1:
					await dialog.Msg("EP15_1_F_ABBEY1_6_DLG2");
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
			if (character.Inventory.HasItem("EP15_1_FABBEY1_MQ_6_ITEM1", 10))
			{
				character.Inventory.RemoveItem("EP15_1_FABBEY1_MQ_6_ITEM1", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP15_1_F_ABBEY1_6_DLG3");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

