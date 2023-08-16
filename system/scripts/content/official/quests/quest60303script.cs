//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60303)]
public class Quest60303Script : QuestScript
{
	protected override void Load()
	{
		SetId(60303);
		SetName("The Fugitive's Dream (6)");
		SetDescription("Talk to Kupole Grisia");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(378));

		AddObjective("collect0", "Collect 6 Neutralizing Orb(s)", new CollectItemObjective("DCAPITAL107_SQ_6_ITEM", 6));
		AddDrop("DCAPITAL107_SQ_6_ITEM", 10f, 59099, 59095);

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 20952));

		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL107_SQ_6_1", "DCAPITAL107_SQ_6", "Yeah, I'll collect them", "I need to prepare"))
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
			if (character.Inventory.HasItem("DCAPITAL107_SQ_6_ITEM", 6))
			{
				character.Inventory.RemoveItem("DCAPITAL107_SQ_6_ITEM", 6);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("DCAPITAL107_SQ_6_3");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

