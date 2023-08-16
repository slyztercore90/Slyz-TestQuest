//--- Melia Script -----------------------------------------------------------
// Evil Magic Circles? (2)
//--- Description -----------------------------------------------------------
// Quest to Search for other magic circles.
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

[QuestScript(80100)]
public class Quest80100Script : QuestScript
{
	protected override void Load()
	{
		SetId(80100);
		SetName("Evil Magic Circles? (2)");
		SetDescription("Search for other magic circles");

		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_1"));
		AddPrerequisite(new LevelPrerequisite(226));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_SQ_2_START", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

