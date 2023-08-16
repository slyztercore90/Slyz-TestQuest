//--- Melia Script -----------------------------------------------------------
// Waters Post (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(60401)]
public class Quest60401Script : QuestScript
{
	protected override void Load()
	{
		SetId(60401);
		SetName("Waters Post (1)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new CompletedPrerequisite("PAYAUTA_EP11_1"));
		AddPrerequisite(new LevelPrerequisite(380));

		AddObjective("collect0", "Collect 8 Stolen Repair Supplies(s)", new CollectItemObjective("PAYAUTA_EP11_2_ITEM", 8));
		AddDrop("PAYAUTA_EP11_2_ITEM", 9f, 59109, 59079, 59078, 59152, 59108);

		AddReward(new ItemReward("expCard16", 1));
		AddReward(new ItemReward("Vis", 20140));

		AddDialogHook("PAYAUTA_EP11_NPC_87", "BeforeStart", BeforeStart);
		AddDialogHook("PAYAUTA_EP11_NPC_87", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PAYAUTA_EP11_2_1", "PAYAUTA_EP11_2", "I will find it", "I need little more time"))
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
			if (character.Inventory.HasItem("PAYAUTA_EP11_2_ITEM", 8))
			{
				character.Inventory.RemoveItem("PAYAUTA_EP11_2_ITEM", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PAYAUTA_EP11_2_3");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

