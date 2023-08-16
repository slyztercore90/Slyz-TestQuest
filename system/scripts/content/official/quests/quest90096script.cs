//--- Melia Script -----------------------------------------------------------
// Crafting Plant Supplement (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90096)]
public class Quest90096Script : QuestScript
{
	protected override void Load()
	{
		SetId(90096);
		SetName("Crafting Plant Supplement (1)");
		SetDescription("Talk to Kupole Lina");

		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(289));

		AddObjective("collect0", "Collect 8 Nutta Fluid(s)", new CollectItemObjective("MAPLE_25_3_SQ_20_ITEM", 8));
		AddDrop("MAPLE_25_3_SQ_20_ITEM", 9f, 58537, 58544);

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("MAPLE_25_3_LINA", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_LINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE_25_3_SQ_20_ST", "MAPLE_25_3_SQ_20", "What can I do for you?", "About the device nearby", "Be strong."))
			{
				case 1:
					await dialog.Msg("MAPLE_25_3_SQ_20_AG");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("MAPLE_25_3_SQ_20_DIS");
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
			if (character.Inventory.HasItem("MAPLE_25_3_SQ_20_ITEM", 8))
			{
				character.Inventory.RemoveItem("MAPLE_25_3_SQ_20_ITEM", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("MAPLE_25_3_SQ_20_SU");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

