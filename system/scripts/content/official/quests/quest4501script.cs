//--- Melia Script -----------------------------------------------------------
// Destroyer of the Main Purifier (2)
//--- Description -----------------------------------------------------------
// Quest to Use the Mine Compass.
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

[QuestScript(4501)]
public class Quest4501Script : QuestScript
{
	protected override void Load()
	{
		SetId(4501);
		SetName("Destroyer of the Main Purifier (2)");
		SetDescription("Use the Mine Compass");
		SetTrack("SProgress", "ESuccess", "mine_2_5", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_14"));
		AddPrerequisite(new LevelPrerequisite(19));

		AddObjective("kill0", "Kill 1 Stone Whale", new KillObjective(41209, 1));

		AddReward(new ExpReward(16116, 16116));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("MINE_2_CRYSTAL_20_ITEM", 1));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_CRYSTAL_20_PART", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("MINE_2_CRYSTAL_20_PART");
			dialog.AddonMessage("NOTICE_Dm_Exclaimation", "You've found the parts of the Purifier{nl}Repair the Main Purifier and activate it", 5);
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("MINE_2_CRYSTAL_20_PART");
	}
}

