//--- Melia Script -----------------------------------------------------------
// To the Right (1)
//--- Description -----------------------------------------------------------
// Quest to Block Marnox from running away to the right.
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

[QuestScript(91065)]
public class Quest91065Script : QuestScript
{
	protected override void Load()
	{
		SetId(91065);
		SetName("To the Right (1)");
		SetDescription("Block Marnox from running away to the right");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_2_3_4_5"), new CompletedPrerequisite("EP13_2_DPRISON3_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddObjective("kill0", "Kill 20 Wendigo Subject(s) or Lunatic Wendigo(s) or Dumaro Subject(s)", new KillObjective(20, 59663, 59662, 59664));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_R_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

