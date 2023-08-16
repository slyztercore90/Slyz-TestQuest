//--- Melia Script -----------------------------------------------------------
// Being Considerate to Elders(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Jacob.
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

[QuestScript(70502)]
public class Quest70502Script : QuestScript
{
	protected override void Load()
	{
		SetId(70502);
		SetName("Being Considerate to Elders(1)");
		SetDescription("Talk to Pilgrim Jacob");

		AddPrerequisite(new LevelPrerequisite(258));

		AddObjective("collect0", "Collect 1 Jacob's Lost Luggage", new CollectItemObjective("PILGRIM41_1_SQ03_ITEM", 1));
		AddDrop("PILGRIM41_1_SQ03_ITEM", 1f, 57903, 57907);

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM411_SQ_03_start", "PILGRIM41_1_SQ03", "What is it? ", "Decline since you are busy and go on your way"))
			{
				case 1:
					await dialog.Msg("PILGRIM411_SQ_03_agree");
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
			if (character.Inventory.HasItem("PILGRIM41_1_SQ03_ITEM", 1))
			{
				character.Inventory.RemoveItem("PILGRIM41_1_SQ03_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PILGRIM411_SQ_03_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

