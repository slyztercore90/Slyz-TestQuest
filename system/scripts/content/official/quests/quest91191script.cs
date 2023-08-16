//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002473
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002589.
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

[QuestScript(91191)]
public class Quest91191Script : QuestScript
{
	protected override void Load()
	{
		SetId(91191);
		SetName("QUEST_LV_0500_20230130_002473");
		SetDescription("QUEST_LV_0500_20230130_002589");

		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("collect0", "Collect 20 ITEM_20230130_028367(s)", new CollectItemObjective("EP15_1_ABBEY1_SQ2_ITEM", 20));
		AddDrop("EP15_1_ABBEY1_SQ2_ITEM", 1f, 59771, 59777);

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY1_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("ORSHA_COLLECTION_SHOP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_ABBEY1_SQ2_DLG1", "EP15_1_ABBEY1_SQ2", "QUEST_LV_0500_20230130_002474", "QUEST_LV_0500_20230130_002475"))
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
			if (character.Inventory.HasItem("EP15_1_ABBEY1_SQ2_ITEM", 20))
			{
				character.Inventory.RemoveItem("EP15_1_ABBEY1_SQ2_ITEM", 20);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP15_1_ABBEY1_SQ2_DLG2");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

