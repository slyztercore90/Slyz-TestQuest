//--- Melia Script -----------------------------------------------------------
// Defeat Vilktys
//--- Description -----------------------------------------------------------
// Quest to Defeat Vilktys.
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

[QuestScript(63000)]
public class Quest63000Script : QuestScript
{
	protected override void Load()
	{
		SetId(63000);
		SetName("Defeat Vilktys");
		SetDescription("Defeat Vilktys");

		AddPrerequisite(new LevelPrerequisite(421));

		AddObjective("kill0", "Kill 25 Vilktys(s)", new KillObjective(59351, 25));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_1", "BeforeStart", BeforeStart);
		AddDialogHook("MISSIONSHOP_EP12_1", "BeforeEnd", BeforeEnd);
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

