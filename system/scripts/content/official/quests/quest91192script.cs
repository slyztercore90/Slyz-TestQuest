//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002476
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002595.
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

[QuestScript(91192)]
public class Quest91192Script : QuestScript
{
	protected override void Load()
	{
		SetId(91192);
		SetName("QUEST_LV_0500_20230130_002476");
		SetDescription("QUEST_LV_0500_20230130_002595");

		AddPrerequisite(new LevelPrerequisite(485));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY2_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_ABBEY2_SQ1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_ABBEY2_SQ1_DLG1", "EP15_1_ABBEY2_SQ1", "QUEST_LV_0500_20230130_002477", "QUEST_LV_0500_20230130_002478"))
			{
				case 1:
					await dialog.Msg("EP15_1_ABBEY2_SQ1_DLG2");
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
			if (character.Inventory.HasItem("EP15_1_F_ABBEY2_MQ_2_ITEM1", 20))
			{
				character.Inventory.RemoveItem("EP15_1_F_ABBEY2_MQ_2_ITEM1", 20);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP15_1_ABBEY2_SQ1_DLG3");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

