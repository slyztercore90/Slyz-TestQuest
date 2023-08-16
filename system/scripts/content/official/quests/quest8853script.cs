//--- Melia Script -----------------------------------------------------------
// Interesting Copy
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Saliamonas.
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

[QuestScript(8853)]
public class Quest8853Script : QuestScript
{
	protected override void Load()
	{
		SetId(8853);
		SetName("Interesting Copy");
		SetDescription("Talk with Alchemist Saliamonas");

		AddPrerequisite(new LevelPrerequisite(196));

		AddObjective("collect0", "Collect 7 Petrified Sample(s)", new CollectItemObjective("FLASH64_SQ_09_ITEM", 7));
		AddDrop("FLASH64_SQ_09_ITEM", 8f, 41299, 47307, 47464);

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_SALIAMONS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_SALIAMONS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH64_SQ_09_01", "FLASH64_SQ_09", "Tell him that you would bring it", "I better get going."))
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
			if (character.Inventory.HasItem("FLASH64_SQ_09_ITEM", 7))
			{
				character.Inventory.RemoveItem("FLASH64_SQ_09_ITEM", 7);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FLASH64_SQ_09_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

