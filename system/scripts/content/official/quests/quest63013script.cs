//--- Melia Script -----------------------------------------------------------
// Grey Wolf
//--- Description -----------------------------------------------------------
// Quest to Grey Wolf.
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

[QuestScript(63013)]
public class Quest63013Script : QuestScript
{
	protected override void Load()
	{
		SetId(63013);
		SetName("Grey Wolf");
		SetDescription("Grey Wolf");

		AddPrerequisite(new LevelPrerequisite(436));

		AddObjective("kill0", "Kill 45 Grey Wolf(s)", new KillObjective(59358, 45));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_4", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

