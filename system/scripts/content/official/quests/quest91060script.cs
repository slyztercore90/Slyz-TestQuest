//--- Melia Script -----------------------------------------------------------
// Secrets Hidden Underground (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Paulius.
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

[QuestScript(91060)]
public class Quest91060Script : QuestScript
{
	protected override void Load()
	{
		SetId(91060);
		SetName("Secrets Hidden Underground (5)");
		SetDescription("Talk to Paulius");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON2_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 25));
		AddReward(new ItemReward("Vis", 28980));

		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_4", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_2_DPRISON2_MQ_NPC_FOLLOW_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_2_DPRISON2_MQ_5_DLG1", "EP13_2_DPRISON2_MQ_5", "Alright", "That's too difficult to do now"))
			{
				case 1:
					await dialog.Msg("FadeOutIN/1000");
					dialog.HideNPC("EP13_2_DPRISON2_MQ_NPC_4");
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
			if (character.Inventory.HasItem("EP13_2_DPRISON2_MQ_ITEM_3", 8))
			{
				character.Inventory.RemoveItem("EP13_2_DPRISON2_MQ_ITEM_3", 8);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP13_2_DPRISON2_MQ_5_DLG2");
				dialog.HideNPC("EP13_2_DPRISON2_MQ_NPC_LOSTARTICLE");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

