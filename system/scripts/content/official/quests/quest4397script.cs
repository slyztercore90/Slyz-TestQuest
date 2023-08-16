//--- Melia Script -----------------------------------------------------------
// Grave's Owner
//--- Description -----------------------------------------------------------
// Quest to Find the grave at the Sunset Flag Forest.
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

[QuestScript(4397)]
public class Quest4397Script : QuestScript
{
	protected override void Load()
	{
		SetId(4397);
		SetName("Grave's Owner");
		SetDescription("Find the grave at the Sunset Flag Forest");
		SetTrack("SProgress", "ESuccess", "THORN23_Q_7_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("kill0", "Kill 1 Mushwort", new KillObjective(57070, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("THORN23_Q_7_TRIGGER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

