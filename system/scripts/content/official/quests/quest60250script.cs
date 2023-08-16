//--- Melia Script -----------------------------------------------------------
// Going Below the Shadow (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Saya.
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

[QuestScript(60250)]
public class Quest60250Script : QuestScript
{
	protected override void Load()
	{
		SetId(60250);
		SetName("Going Below the Shadow (3)");
		SetDescription("Talk to Kupole Saya");

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB482_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(338));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY482_SVAJA_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY482_SVAJA_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB482_MQ_3_1", "FANTASYLIB482_MQ_3", "Yeah, I'll collect them", "I'll wait a little bit"))
			{
				case 1:
					dialog.UnHideNPC("FANTASYLIB482_MQ_3_NPC");
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
			if (character.Inventory.HasItem("FANTASYLIB482_MQ_3_ITEM", 8))
			{
				character.Inventory.RemoveItem("FANTASYLIB482_MQ_3_ITEM", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FANTASYLIB482_MQ_3_3");
				dialog.HideNPC("FANTASYLIB482_MQ_3_NPC");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

