//--- Melia Script -----------------------------------------------------------
// Defeat the Viskal
//--- Description -----------------------------------------------------------
// Quest to Defeat the Viskal.
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

[QuestScript(63004)]
public class Quest63004Script : QuestScript
{
	protected override void Load()
	{
		SetId(63004);
		SetName("Defeat the Viskal");
		SetDescription("Defeat the Viskal");

		AddPrerequisite(new LevelPrerequisite(421));

		AddObjective("kill0", "Kill 10 Viskal(s)", new KillObjective(59350, 10));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

