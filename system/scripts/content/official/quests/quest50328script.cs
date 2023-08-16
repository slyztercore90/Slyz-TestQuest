//--- Melia Script -----------------------------------------------------------
// Creating Distractions (1)
//--- Description -----------------------------------------------------------
// Quest to Read the instruction.
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

[QuestScript(50328)]
public class Quest50328Script : QuestScript
{
	protected override void Load()
	{
		SetId(50328);
		SetName("Creating Distractions (1)");
		SetDescription("Read the instruction");

		AddPrerequisite(new CompletedPrerequisite("WTREES22_2_SQ2"));
		AddPrerequisite(new LevelPrerequisite(348));

		AddObjective("kill0", "Kill 28 Yakyak(s) or Yak Warrior(s) or Yak Druid(s)", new KillObjective(28, 58843, 58847, 58848));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("Vis", 16704));
		AddReward(new ItemReward("expCard15", 1));

		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES22_2_SUBQ1_NPC1", "BeforeEnd", BeforeEnd);
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WTREES22_2_SQ4");
	}
}

