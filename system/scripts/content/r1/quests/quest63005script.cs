//--- Melia Script -----------------------------------------------------------
// Defeat the Stagvalus
//--- Description -----------------------------------------------------------
// Quest to Defeat the Stagvalus.
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

[QuestScript(63005)]
public class Quest63005Script : QuestScript
{
	protected override void Load()
	{
		SetId(63005);
		SetName("Defeat the Stagvalus");
		SetDescription("Defeat the Stagvalus");

		AddPrerequisite(new LevelPrerequisite(426));

		AddObjective("kill0", "Kill 10 Stagvalus(s)", new KillObjective(10, MonsterId.Castle_Beetle));

		AddReward(new ItemReward("Ability_Point_Stone_500_14d", 1));
		AddReward(new ItemReward("expCard17", 2));

		AddDialogHook("MISSIONSHOP_EP12_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

