//--- Melia Script -----------------------------------------------------------
// Demon Cauldron (2)
//--- Description -----------------------------------------------------------
// Quest to Destroy the Demon Cauldrons.
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

[QuestScript(50115)]
public class Quest50115Script : QuestScript
{
	protected override void Load()
	{
		SetId(50115);
		SetName("Demon Cauldron (2)");
		SetDescription("Destroy the Demon Cauldrons");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_SQ020"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

