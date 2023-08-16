//--- Melia Script -----------------------------------------------------------
// Fix the Central Purifier (2)
//--- Description -----------------------------------------------------------
// Quest to Search District 4 for the Spare Purifier.
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

[QuestScript(4470)]
public class Quest4470Script : QuestScript
{
	protected override void Load()
	{
		SetId(4470);
		SetName("Fix the Central Purifier (2)");
		SetDescription("Search District 4 for the Spare Purifier");
		SetTrack("SProgress", "ESuccess", "MINE_1_CRYSTAL_9_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("MINE_1_CRYSTAL_8"));
		AddPrerequisite(new LevelPrerequisite(17));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 221));

		AddDialogHook("MINE_1_PURIFY_5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("MINE_1_CRYSTAL_9_ITEM", 1))
			{
				character.Inventory.RemoveItem("MINE_1_CRYSTAL_9_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				dialog.AddonMessage("NOTICE_Dm_Clear", "Repaired the Central Purifier!{nl}The Purifier is working again!");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.AddonMessage("NOTICE_Dm_Clear", "The Mine Compass is pointing at District 4{nl}Go to District 4 and look for the spare part");
	}
}

