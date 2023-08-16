//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002479
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002601.
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

[QuestScript(91193)]
public class Quest91193Script : QuestScript
{
	protected override void Load()
	{
		SetId(91193);
		SetName("QUEST_LV_0500_20230130_002479");
		SetDescription("QUEST_LV_0500_20230130_002601");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_ABBEY2_SQ1"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddObjective("collect0", "Collect 25 ITEM_20230130_028369(s)", new CollectItemObjective("EP15_1_ABBEY2_SQ2_ITEM", 25));
		AddDrop("EP15_1_ABBEY2_SQ2_ITEM", 2f, 59777, 59780, 59778);

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
			switch (await dialog.Select("EP15_1_ABBEY2_SQ2_DLG1", "EP15_1_ABBEY2_SQ2", "Alright", "QUEST_LV_0500_20230130_002480"))
			{
				case 1:
					await dialog.Msg("EP15_1_ABBEY2_SQ2_DLG2");
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
			if (character.Inventory.HasItem("EP15_1_ABBEY2_SQ2_ITEM", 25))
			{
				character.Inventory.RemoveItem("EP15_1_ABBEY2_SQ2_ITEM", 25);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP15_1_ABBEY2_SQ2_DLG3");
				await dialog.Msg("FadeOutIN/2500");
				dialog.HideNPC("EP15_1_ABBEY2_SQ1_NPC");
				// Func/SCR_EP15_1_ABBEY2_SQ2_balloontext;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

