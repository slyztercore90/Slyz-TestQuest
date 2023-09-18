//--- Melia Script -----------------------------------------------------------
// Legwyn Family's Seal [Squire Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Squire Master.
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

[QuestScript(30032)]
public class Quest30032Script : QuestScript
{
	protected override void Load()
	{
		SetId(30032);
		SetName("Legwyn Family's Seal [Squire Advancement]");
		SetDescription("Talk to the Squire Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddObjective("collect0", "Collect 10 Broken Legwyn Seal Fragment(s)", new CollectItemObjective("JOB_SQUIRE_6_1_ITEM", 10));
		AddDrop("JOB_SQUIRE_6_1_ITEM", 1f, 57480, 57461, 57462, 57644);

		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_SQUIRE_6_1_select", "JOB_SQUIRE_6_1", "Accept", "Reject"))
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

		if (character.Inventory.HasItem("JOB_SQUIRE_6_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_SQUIRE_6_1_ITEM", 10);
			await dialog.Msg("JOB_SQUIRE_6_1_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

