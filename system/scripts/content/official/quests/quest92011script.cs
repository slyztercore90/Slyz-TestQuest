//--- Melia Script -----------------------------------------------------------
// The Last Protective Device (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rangda Master.
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

[QuestScript(92011)]
public class Quest92011Script : QuestScript
{
	protected override void Load()
	{
		SetId(92011);
		SetName("The Last Protective Device (2)");
		SetDescription("Talk to the Rangda Master");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_D_DCAPITAL_108_MQ11"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddObjective("collect0", "Collect 7 Raganosis Blood(s)", new CollectItemObjective("EP12_2_D_DCAPITAL_108_MQ11_ITEM_01", 7));
		AddDrop("EP12_2_D_DCAPITAL_108_MQ11_ITEM_01", 10f, 59527, 59530, 59528);

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT_108", "BeforeStart", BeforeStart);
		AddDialogHook("RANGDAMASTER_FOLLOWNPC_CHAT_108", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_D_DCAPITAL_108_MQ12_DLG1", "EP12_2_D_DCAPITAL_108_MQ12", "I'll get them in no time.", "I'm not ready yet."))
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
			if (character.Inventory.HasItem("EP12_2_D_DCAPITAL_108_MQ11_ITEM_01", 7))
			{
				character.Inventory.RemoveItem("EP12_2_D_DCAPITAL_108_MQ11_ITEM_01", 7);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP12_2_D_DCAPITAL_108_MQ12_DLG2");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP12_2_D_DCAPITAL_108_MQ13");
	}
}

