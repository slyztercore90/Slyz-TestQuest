//--- Melia Script -----------------------------------------------------------
// Attack of the Gray Golem
//--- Description -----------------------------------------------------------
// Quest to Defeat the Gray Golem that suddenly appeared.
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

[QuestScript(8219)]
public class Quest8219Script : QuestScript
{
	protected override void Load()
	{
		SetId(8219);
		SetName("Attack of the Gray Golem");
		SetDescription("Defeat the Gray Golem that suddenly appeared");
		SetTrack("SPossible", "ESuccess", "KATYN72_SUB_03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(109));

		AddObjective("kill0", "Kill 1 Gray Golem", new KillObjective(450222, 1));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_GOLEMLET", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

