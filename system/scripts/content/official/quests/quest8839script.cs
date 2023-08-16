//--- Melia Script -----------------------------------------------------------
// Small Difference (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Grave Robber Stephonas.
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

[QuestScript(8839)]
public class Quest8839Script : QuestScript
{
	protected override void Load()
	{
		SetId(8839);
		SetName("Small Difference (3)");
		SetDescription("Talk with Grave Robber Stephonas");

		AddPrerequisite(new CompletedPrerequisite("FLASH63_SQ_06"));
		AddPrerequisite(new LevelPrerequisite(193));

		AddObjective("collect0", "Collect 8 Sticky Fluid(s)", new CollectItemObjective("FLASH63_SQ_07_ITEM", 8));
		AddDrop("FLASH63_SQ_07_ITEM", 10f, 47306, 57636, 57634);

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_STEPONAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_STEPONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH63_SQ_07_01", "FLASH63_SQ_07", "Tell him that you would gather them", "Decline"))
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
			if (character.Inventory.HasItem("FLASH63_SQ_07_ITEM", 8))
			{
				character.Inventory.RemoveItem("FLASH63_SQ_07_ITEM", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FLASH63_SQ_07_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

