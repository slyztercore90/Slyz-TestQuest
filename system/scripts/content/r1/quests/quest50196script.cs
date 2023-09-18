//--- Melia Script -----------------------------------------------------------
// The Goddess' Flower (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Gherriti.
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

[QuestScript(50196)]
public class Quest50196Script : QuestScript
{
	protected override void Load()
	{
		SetId(50196);
		SetName("The Goddess' Flower (4)");
		SetDescription("Talk with Priest Gherriti");

		AddPrerequisite(new LevelPrerequisite(307));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN43_1_SQ3"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14122));

		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN431_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN43_1_SQ4_START1", "BRACKEN43_1_SQ4", "I'll go find it", "I will obtain them later"))
		{
			case 1:
				await dialog.Msg("BRACKEN43_1_SQ4_AG");
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

		if (character.Inventory.HasItem("BRACKEN431_SUBQ4_ITEM1", 10))
		{
			character.Inventory.RemoveItem("BRACKEN431_SUBQ4_ITEM1", 10);
			await dialog.Msg("BRACKEN43_1_SQ4_SUCC1");
			character.Quests.Complete(this.QuestId);
			// Func/BRACKEN431_SUBQ4_COMPLETE;
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("BRACKEN43_1_SQ4_SUCC2");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

