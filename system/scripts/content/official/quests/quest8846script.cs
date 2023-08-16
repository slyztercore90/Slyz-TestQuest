//--- Melia Script -----------------------------------------------------------
// Refreshing Work
//--- Description -----------------------------------------------------------
// Quest to Talk to Wilhelmina Carriot.
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

[QuestScript(8846)]
public class Quest8846Script : QuestScript
{
	protected override void Load()
	{
		SetId(8846);
		SetName("Refreshing Work");
		SetDescription("Talk to Wilhelmina Carriot");

		AddPrerequisite(new CompletedPrerequisite("FLASH64_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(196));

		AddObjective("collect0", "Collect 8 Cough Medicine(s)", new CollectItemObjective("FLASH64_SQ_02_ITEM", 8));
		AddDrop("FLASH64_SQ_02_ITEM", 8.5f, 41299, 47307, 47464);

		AddReward(new ExpReward(2379430, 2379430));
		AddReward(new ItemReward("expCard10", 2));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_KARRIAT", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_KARRIAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH64_SQ_02_01", "FLASH64_SQ_02", "I'll retrieve it", "Decline"))
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
			if (character.Inventory.HasItem("FLASH64_SQ_02_ITEM", 8))
			{
				character.Inventory.RemoveItem("FLASH64_SQ_02_ITEM", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FLASH64_SQ_02_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

