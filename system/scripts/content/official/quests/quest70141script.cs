//--- Melia Script -----------------------------------------------------------
// Proof of Strength
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70141)]
public class Quest70141Script : QuestScript
{
	protected override void Load()
	{
		SetId(70141);
		SetName("Proof of Strength");
		SetDescription("Talk to Senior Monk Goss");

		AddPrerequisite(new CompletedPrerequisite("THORN39_3_MQ01"));
		AddPrerequisite(new LevelPrerequisite(179));

		AddReward(new ExpReward(1256004, 1256004));
		AddReward(new ItemReward("expCard9", 4));
		AddReward(new ItemReward("Vis", 5370));

		AddDialogHook("THORN393_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_3_MQ_02_1", "THORN39_3_MQ02", "I will prove my abilities", "I don't feel it"))
			{
				case 1:
					await dialog.Msg("THORN39_3_MQ_02_2");
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
			if (character.Inventory.HasItem("THORN39_3_MQ02_ITEM_1", 4) && character.Inventory.HasItem("THORN39_3_MQ02_ITEM_2", 12))
			{
				character.Inventory.RemoveItem("THORN39_3_MQ02_ITEM_1", 4);
				character.Inventory.RemoveItem("THORN39_3_MQ02_ITEM_2", 12);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("THORN39_3_MQ_02_4");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

