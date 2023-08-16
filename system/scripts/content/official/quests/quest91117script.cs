//--- Melia Script -----------------------------------------------------------
// Abandoned Weapon
//--- Description -----------------------------------------------------------
// Quest to Join the General Ramin in Delmore Garden.
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

[QuestScript(91117)]
public class Quest91117Script : QuestScript
{
	protected override void Load()
	{
		SetId(91117);
		SetName("Abandoned Weapon");
		SetDescription("Join the General Ramin in Delmore Garden");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(468));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29952));

		AddDialogHook("EP14_1_FCASTLE5_MQ_1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_1_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_1_FCASTLE5_MQ_1_SNPC_DLG1", "EP14_1_FCASTLE5_MQ_1", "I'll follow your order", "I need to prepare to follow your order"))
			{
				case 1:
					await dialog.Msg("EP14_1_FCASTLE5_MQ_1_SNPC_DLG2");
					// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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
			if (character.Inventory.HasItem("EP14_1_FCASTLE5_MQ_1_ITEM4", 50) && character.Inventory.HasItem("EP14_1_FCASTLE5_MQ_1_ITEM1", 50) && character.Inventory.HasItem("EP14_1_FCASTLE5_MQ_1_ITEM2", 1))
			{
				character.Inventory.RemoveItem("EP14_1_FCASTLE5_MQ_1_ITEM4", 50);
				character.Inventory.RemoveItem("EP14_1_FCASTLE5_MQ_1_ITEM1", 50);
				character.Inventory.RemoveItem("EP14_1_FCASTLE5_MQ_1_ITEM2", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP14_1_FCASTLE5_MQ_1_CNPC_DLG1");
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

