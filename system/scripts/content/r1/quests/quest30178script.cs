//--- Melia Script -----------------------------------------------------------
// Shard Collection(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30178)]
public class Quest30178Script : QuestScript
{
	protected override void Load()
	{
		SetId(30178);
		SetName("Shard Collection(1)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(269));
		AddPrerequisite(new CompletedPrerequisite("PRISON_81_MQ_4"));

		AddObjective("collect0", "Collect 1 Fire Fragment", new CollectItemObjective("PRISON_81_MQ_5_ITEM_1", 1));
		AddObjective("collect1", "Collect 1 Ice Fragment", new CollectItemObjective("PRISON_81_MQ_5_ITEM_2", 1));
		AddObjective("collect2", "Collect 1 Lightning Fragment", new CollectItemObjective("PRISON_81_MQ_5_ITEM_3", 1));
		AddObjective("collect3", "Collect 1 Poison Fragment", new CollectItemObjective("PRISON_81_MQ_5_ITEM_4", 1));
		AddDrop("PRISON_81_MQ_5_ITEM_1", 5f, 57985, 57987, 57952);
		AddDrop("PRISON_81_MQ_5_ITEM_2", 3f, 57985, 57987, 57952);
		AddDrop("PRISON_81_MQ_5_ITEM_3", 1f, 57985, 57987, 57952);
		AddDrop("PRISON_81_MQ_5_ITEM_4", 0.5f, 57985, 57987, 57952);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11029));

		AddDialogHook("PRISON_81_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_81_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_81_MQ_5_select", "PRISON_81_MQ_5", "Say that you think it is a good idea", "Say that you think it is better to head directly to Nebulas"))
		{
			case 1:
				await dialog.Msg("PRISON_81_MQ_5_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("PRISON_81_MQ_5_ITEM_1", 1) && character.Inventory.HasItem("PRISON_81_MQ_5_ITEM_2", 1) && character.Inventory.HasItem("PRISON_81_MQ_5_ITEM_3", 1) && character.Inventory.HasItem("PRISON_81_MQ_5_ITEM_4", 1))
		{
			character.Inventory.RemoveItem("PRISON_81_MQ_5_ITEM_1", 1);
			character.Inventory.RemoveItem("PRISON_81_MQ_5_ITEM_2", 1);
			character.Inventory.RemoveItem("PRISON_81_MQ_5_ITEM_3", 1);
			character.Inventory.RemoveItem("PRISON_81_MQ_5_ITEM_4", 1);
			await dialog.Msg("PRISON_81_MQ_5_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

