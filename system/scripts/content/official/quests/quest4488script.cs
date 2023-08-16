//--- Melia Script -----------------------------------------------------------
// Inoperable Auxiliary Purifier (2)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Magic Supply Device.
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

[QuestScript(4488)]
public class Quest4488Script : QuestScript
{
	protected override void Load()
	{
		SetId(4488);
		SetName("Inoperable Auxiliary Purifier (2)");
		SetDescription("Inspect the Magic Supply Device");

		AddPrerequisite(new CompletedPrerequisite("MINE_2_CRYSTAL_5"));
		AddPrerequisite(new LevelPrerequisite(19));

		AddReward(new ExpReward(10744, 10744));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 247));

		AddDialogHook("MINE_2_CRYSTAL_7_ENERGY", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

