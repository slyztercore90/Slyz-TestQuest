//--- Melia Script -----------------------------------------------------------
// Get a Hold of Yourself! (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Donatas.
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

[QuestScript(8451)]
public class Quest8451Script : QuestScript
{
	protected override void Load()
	{
		SetId(8451);
		SetName("Get a Hold of Yourself! (1)");
		SetDescription("Talk to Follower Donatas");

		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 6 Pawnd's Soul(s)", new CollectItemObjective("CHAPLE576_MQ_07_1_ITEM", 6));
		AddObjective("collect1", "Collect 6 Pawndel's Soul(s)", new CollectItemObjective("CHAPLE576_MQ_07_2_ITEM", 6));
		AddObjective("collect2", "Collect 6 Corylus' Soul(s)", new CollectItemObjective("CHAPLE576_MQ_07_3_ITEM", 6));
		AddDrop("CHAPLE576_MQ_07_1_ITEM", 8f, "pawnd");
		AddDrop("CHAPLE576_MQ_07_2_ITEM", 8f, "Pawndel");
		AddDrop("CHAPLE576_MQ_07_3_ITEM", 8f, "Corylus");

		AddReward(new ExpReward(25326, 25326));
		AddReward(new ItemReward("expCard3", 3));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("CHAPEL576_DONATAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL576_DONATAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE576_MQ_07_01", "CHAPLE576_MQ_07", "I'll try to do it", "I'll wait a little bit"))
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
			if (character.Inventory.HasItem("CHAPLE576_MQ_07_1_ITEM", 6) && character.Inventory.HasItem("CHAPLE576_MQ_07_2_ITEM", 6) && character.Inventory.HasItem("CHAPLE576_MQ_07_3_ITEM", 6))
			{
				character.Inventory.RemoveItem("CHAPLE576_MQ_07_1_ITEM", 6);
				character.Inventory.RemoveItem("CHAPLE576_MQ_07_2_ITEM", 6);
				character.Inventory.RemoveItem("CHAPLE576_MQ_07_3_ITEM", 6);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CHAPLE576_MQ_07_03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

