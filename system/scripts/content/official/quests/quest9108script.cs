//--- Melia Script -----------------------------------------------------------
// Mercenary Lindt's Favor
//--- Description -----------------------------------------------------------
// Quest to Talk to Mercenary Lindt.
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

[QuestScript(9108)]
public class Quest9108Script : QuestScript
{
	protected override void Load()
	{
		SetId(9108);
		SetName("Mercenary Lindt's Favor");
		SetDescription("Talk to Mercenary Lindt");

		AddPrerequisite(new CompletedPrerequisite("ROKAS26_SUB_Q05"));
		AddPrerequisite(new LevelPrerequisite(1));

		AddObjective("collect0", "Collect 5 Dumaro's Hind Leg(s)", new CollectItemObjective("DUMARO_MEAT", 5));
		AddDrop("DUMARO_MEAT", 3f, "Dumaro");

		AddDialogHook("ROKAS26_LINT", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS26_LINT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS_26_HQ_01_select01", "ROKAS_26_HQ_01", "I'll share the food", "Refuse"))
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
			if (character.Inventory.HasItem("DUMARO_MEAT", 5))
			{
				character.Inventory.RemoveItem("DUMARO_MEAT", 5);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("ROKAS_26_HQ_01_succ01");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

