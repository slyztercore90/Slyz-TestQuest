//--- Melia Script -----------------------------------------------------------
// Defeat the Akhlass Petal Warrior
//--- Description -----------------------------------------------------------
// Quest to Defeat the Akhlass Petal Warrior.
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

[QuestScript(63009)]
public class Quest63009Script : QuestScript
{
	protected override void Load()
	{
		SetId(63009);
		SetName("Defeat the Akhlass Petal Warrior");
		SetDescription("Defeat the Akhlass Petal Warrior");

		AddPrerequisite(new LevelPrerequisite(431));

		AddObjective("kill0", "Kill 45 Akhlass Petal Warrior(s)", new KillObjective(59324, 45));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

