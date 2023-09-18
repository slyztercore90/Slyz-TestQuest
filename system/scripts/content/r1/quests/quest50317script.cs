//--- Melia Script -----------------------------------------------------------
// I Can Hear You Singing (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Indrea.
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

[QuestScript(50317)]
public class Quest50317Script : QuestScript
{
	protected override void Load()
	{
		SetId(50317);
		SetName("I Can Hear You Singing (2)");
		SetDescription("Talk to Indrea");

		AddPrerequisite(new LevelPrerequisite(344));
		AddPrerequisite(new CompletedPrerequisite("WTREES22_1_SQ1"));

		AddObjective("collect0", "Collect 17 Yellow Atti Juice(s)", new CollectItemObjective("WTREES22_1_SUBQ2_ITEM1", 17));
		AddDrop("WTREES22_1_SUBQ2_ITEM1", 9f, "atti");

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16512));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES221_SUBQ_NPC2", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES221_SUBQ_NPC2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("WTREES22_1_SUBQ2_START1", "WTREES22_1_SQ2", "From which monster is the yellow juice from?", "I can't. Ask someone else for help."))
		{
			case 1:
				await dialog.Msg("WTREES22_1_SUBQ2_AGREE1");
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

		if (character.Inventory.HasItem("WTREES22_1_SUBQ2_ITEM1", 17))
		{
			character.Inventory.RemoveItem("WTREES22_1_SUBQ2_ITEM1", 17);
			await dialog.Msg("WTREES22_1_SUBQ2_SUCC1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

