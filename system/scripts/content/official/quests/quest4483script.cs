//--- Melia Script -----------------------------------------------------------
// Circulation Purifier Issues (1)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Circulation Purifier.
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

[QuestScript(4483)]
public class Quest4483Script : QuestScript
{
	protected override void Load()
	{
		SetId(4483);
		SetName("Circulation Purifier Issues (1)");
		SetDescription("Inspect the Circulation Purifier");

		AddPrerequisite(new CompletedPrerequisite("MINE_2_ALCHEMIST"));
		AddPrerequisite(new LevelPrerequisite(19));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_PURIFY_1", "BeforeStart", BeforeStart);
		AddDialogHook("MINE_2_PURIFY_1", "BeforeEnd", BeforeEnd);
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
			character.Quests.Complete(this.QuestId);
			dialog.AddonMessage("NOTICE_Dm_Exclaimation", "The Purifier is still not working{nl}Inspect the Purifier at District 2", 5);
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MINE_2_CRYSTAL_3");
	}
}

