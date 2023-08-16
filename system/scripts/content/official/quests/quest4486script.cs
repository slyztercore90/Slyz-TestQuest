//--- Melia Script -----------------------------------------------------------
// Inoperable Auxiliary Purifier (1)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Auxiliary Purifier on 2F.
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

[QuestScript(4486)]
public class Quest4486Script : QuestScript
{
	protected override void Load()
	{
		SetId(4486);
		SetName("Inoperable Auxiliary Purifier (1)");
		SetDescription("Inspect the Auxiliary Purifier on 2F");

		AddPrerequisite(new CompletedPrerequisite("MINE_2_ALCHEMIST"));
		AddPrerequisite(new LevelPrerequisite(19));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_PURIFY_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

