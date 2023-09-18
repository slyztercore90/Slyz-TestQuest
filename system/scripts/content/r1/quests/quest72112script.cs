//--- Melia Script -----------------------------------------------------------
// Where is the Recruit? (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Abraomas.
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

[QuestScript(72112)]
public class Quest72112Script : QuestScript
{
	protected override void Load()
	{
		SetId(72112);
		SetName("Where is the Recruit? (1)");
		SetDescription("Talk to Abraomas");

		AddPrerequisite(new LevelPrerequisite(333));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE261_SQ01"));

		AddObjective("collect0", "Collect 1 Used Arrow", new CollectItemObjective("3CMLAKE261_SQ13_ITEM01", 1));
		AddObjective("collect1", "Collect 1 Blue-colored Cloth", new CollectItemObjective("3CMLAKE261_SQ13_ITEM02", 1));
		AddObjective("collect2", "Collect 1 Someone's Pendant", new CollectItemObjective("3CMLAKE261_SQ13_ITEM03", 1));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15651));

		AddDialogHook("3CMLAKE_ABRAOMAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_ABRAOMAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("3CMLAKE261_SQ13_DLG01", "F_3CMLAKE261_SQ13", "I will search for it", "That's too much to ask of me."))
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

		if (character.Inventory.HasItem("3CMLAKE261_SQ13_ITEM01", 1) && character.Inventory.HasItem("3CMLAKE261_SQ13_ITEM02", 1) && character.Inventory.HasItem("3CMLAKE261_SQ13_ITEM03", 1))
		{
			character.Inventory.RemoveItem("3CMLAKE261_SQ13_ITEM01", 1);
			character.Inventory.RemoveItem("3CMLAKE261_SQ13_ITEM02", 1);
			character.Inventory.RemoveItem("3CMLAKE261_SQ13_ITEM03", 1);
			await dialog.Msg("3CMLAKE261_SQ13_DLG03");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

