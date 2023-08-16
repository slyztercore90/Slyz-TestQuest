//--- Melia Script -----------------------------------------------------------
// Grace of Wealth [Pardoner Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Equipment Merchant in Fedimian.
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

[QuestScript(17520)]
public class Quest17520Script : QuestScript
{
	protected override void Load()
	{
		SetId(17520);
		SetName("Grace of Wealth [Pardoner Advancement] (3)");
		SetDescription("Talk to Equipment Merchant in Fedimian");

		AddPrerequisite(new CompletedPrerequisite("JOB_PARDONER4_1"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("collect0", "Collect 20 Hardened Oil(s)", new CollectItemObjective("JOB_PARDONER4_3_ITEM", 20));
		AddDrop("JOB_PARDONER4_3_ITEM", 10f, "puragi_blue");

		AddDialogHook("FED_EQUIP", "BeforeStart", BeforeStart);
		AddDialogHook("FED_EQUIP", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PARDONER4_3_ST", "JOB_PARDONER4_3", "I'll accept your request", "I'm busy"))
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
			if (character.Inventory.HasItem("JOB_PARDONER4_3_ITEM", 20))
			{
				character.Inventory.RemoveItem("JOB_PARDONER4_3_ITEM", 20);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_PARDONER4_3_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

