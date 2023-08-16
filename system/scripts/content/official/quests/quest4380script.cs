//--- Melia Script -----------------------------------------------------------
// Attack of the Giant Red Wood Goblin
//--- Description -----------------------------------------------------------
// Quest to Inspect the Rotten Stump.
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

[QuestScript(4380)]
public class Quest4380Script : QuestScript
{
	protected override void Load()
	{
		SetId(4380);
		SetName("Attack of the Giant Red Wood Goblin");
		SetDescription("Inspect the Rotten Stump");
		SetTrack("SProgress", "ESuccess", "THORN22_Q_9_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("kill0", "Kill 1 Giant Red Wood Goblin", new KillObjective(41215, 1));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_Q_9_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_Q_9_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

