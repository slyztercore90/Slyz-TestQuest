//--- Melia Script -----------------------------------------------------------
// Deciphering the Mysterious Writings (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Bokor Master.
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

[QuestScript(50281)]
public class Quest50281Script : QuestScript
{
	protected override void Load()
	{
		SetId(50281);
		SetName("Deciphering the Mysterious Writings (3)");
		SetDescription("Talk to the Bokor Master");

		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD362_HQ2"));
		AddPrerequisite(new LevelPrerequisite(151));

		AddReward(new ItemReward("Gacha_H_001", 1));

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIMROAD362_HQ3_start1", "PILGRIMROAD362_HQ3", "We must find them by any means we have.", "Tell him to make his apprentices get it"))
			{
				case 1:
					await dialog.Msg("PILGRIMROAD362_HQ3_agree1");
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
			if (character.Inventory.HasItem("PILGRIMROAD362_HIDDENQ1_ITEM4", 4))
			{
				character.Inventory.RemoveItem("PILGRIMROAD362_HIDDENQ1_ITEM4", 4);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PILGRIMROAD362_HQ3_succ1");
				// Func/PILGRIM362_HIDDENQ1_COMP;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

