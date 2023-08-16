//--- Melia Script -----------------------------------------------------------
// Incomplete Purifier
//--- Description -----------------------------------------------------------
// Quest to Inspect the Entrance Purifier on the 1st Floor.
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

[QuestScript(4463)]
public class Quest4463Script : QuestScript
{
	protected override void Load()
	{
		SetId(4463);
		SetName("Incomplete Purifier");
		SetDescription("Inspect the Entrance Purifier on the 1st Floor");

		AddPrerequisite(new CompletedPrerequisite("MINE_1_ALCHEMIST"));
		AddPrerequisite(new LevelPrerequisite(17));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Drug_SP1_Q", 15));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("MINE_1_PURIFY_1", "BeforeStart", BeforeStart);
		AddDialogHook("MINE_1_PURIFY_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("MINE_1_CRYSTAL_2_ITEM", 1))
			{
				character.Inventory.RemoveItem("MINE_1_CRYSTAL_2_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				dialog.AddonMessage("NOTICE_Dm_Clear", "The repair is done!{nl}The Entrance Purifier is working again!");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

