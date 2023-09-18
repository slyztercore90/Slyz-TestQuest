//--- Melia Script -----------------------------------------------------------
// Marks of a legend(9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Mechen.
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

[QuestScript(50219)]
public class Quest50219Script : QuestScript
{
	protected override void Load()
	{
		SetId(50219);
		SetName("Marks of a legend(9)");
		SetDescription("Talk to Mechen");

		AddPrerequisite(new LevelPrerequisite(313));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_3_SQ8"));

		AddObjective("collect0", "Collect 8 Vilkas Essence(s)", new CollectItemObjective("BRACKEN433_SUBQ9_ITEM1", 8));
		AddDrop("BRACKEN433_SUBQ9_ITEM1", 10f, 58453, 58457);

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14398));
		AddReward(new ItemReward("BRACKEN433_SUBQ9_ITEM2", 1));

		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN433_SUBQ2_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_3_SQ9_START1", "BRACKEN43_3_SQ9", "Go and retrieve Vilkas essence", "Tell him to make his apprentices get it"))
		{
			case 1:
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

		if (character.Inventory.HasItem("BRACKEN433_SUBQ9_ITEM1", 8))
		{
			character.Inventory.RemoveItem("BRACKEN433_SUBQ9_ITEM1", 8);
			await dialog.Msg("BRACKEN43_3_SQ9_SUCC1");
			character.Quests.Complete(this.QuestId);
			// Func/BRACKEN433_SUBQ9_COM_FUNC;
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

