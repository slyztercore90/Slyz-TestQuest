//--- Melia Script -----------------------------------------------------------
// Walking on the Seeds
//--- Description -----------------------------------------------------------
// Quest to Help Marius.
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

[QuestScript(40170)]
public class Quest40170Script : QuestScript
{
	protected override void Load()
	{
		SetId(40170);
		SetName("Walking on the Seeds");
		SetDescription("Help Marius");

		AddPrerequisite(new LevelPrerequisite(84));

		AddObjective("collect0", "Collect 1 Seed Bag", new CollectItemObjective("FARM47_4_SQ_120_ITEM_1", 1));
		AddDrop("FARM47_4_SQ_120_ITEM_1", 1f, 57348, 400984, 57608);

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("FARM47_MARIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_MARIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_4_SQ_120_ST", "FARM47_4_SQ_120", "Alright", "Decline"))
			{
				case 1:
					await dialog.Msg("FARM47_4_SQ_120_AC");
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
			if (character.Inventory.HasItem("FARM47_4_SQ_120_ITEM_1", 1))
			{
				character.Inventory.RemoveItem("FARM47_4_SQ_120_ITEM_1", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FARM47_4_SQ_120_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

