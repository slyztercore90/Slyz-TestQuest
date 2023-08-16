//--- Melia Script -----------------------------------------------------------
// Designated Area (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Molly.
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

[QuestScript(50031)]
public class Quest50031Script : QuestScript
{
	protected override void Load()
	{
		SetId(50031);
		SetName("Designated Area (1)");
		SetDescription("Talk to Watcher Molly");

		AddPrerequisite(new LevelPrerequisite(100));

		AddObjective("collect0", "Collect 35 Fisherman Eye(s)", new CollectItemObjective("PARTY_Q2_FISHERMAN", 35));
		AddObjective("collect1", "Collect 30 Ellom Essence(s)", new CollectItemObjective("PARTY_Q2_ELLOM", 30));
		AddDrop("PARTY_Q2_FISHERMAN", 9f, "Fisherman");
		AddDrop("PARTY_Q2_ELLOM", 8f, "ellom");

		AddDialogHook("GELE571_NPC_MARLEY", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_MARLEY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PARTY_Q_030_startnpc01", "PARTY_Q_030", "Tell him not to worry since you will help out", "Comfort him to cheer him up"))
			{
				case 1:
					await dialog.Msg("PARTY_Q_030_startnpc02");
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
			if (character.Inventory.HasItem("PARTY_Q2_FISHERMAN", 35) && character.Inventory.HasItem("PARTY_Q2_ELLOM", 30))
			{
				character.Inventory.RemoveItem("PARTY_Q2_FISHERMAN", 35);
				character.Inventory.RemoveItem("PARTY_Q2_ELLOM", 30);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PARTY_Q_030_succ01");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

