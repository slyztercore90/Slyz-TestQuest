//--- Melia Script -----------------------------------------------------------
// Necessary Mistake (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60258)]
public class Quest60258Script : QuestScript
{
	protected override void Load()
	{
		SetId(60258);
		SetName("Necessary Mistake (4)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB483_MQ_3"));
		AddPrerequisite(new LevelPrerequisite(341));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 6));

		AddDialogHook("FLIBRARY483_NERINGA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY483_NERINGA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB483_MQ_4_1", "FANTASYLIB483_MQ_4", "Yeah, I'll collect them", "I need to prepare"))
			{
				case 1:
					dialog.UnHideNPC("FANTASYLIB483_MQ_4_NPC");
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
			if (character.Inventory.HasItem("FANTASYLIB483_MQ_4_ITEM", 10))
			{
				character.Inventory.RemoveItem("FANTASYLIB483_MQ_4_ITEM", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FANTASYLIB483_MQ_4_3");
				dialog.UnHideNPC("FANTASYLIB483_MQ_4_NPC");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

