//--- Melia Script -----------------------------------------------------------
// Defeat the monsters blocking the road
//--- Description -----------------------------------------------------------
// Quest to Interruption of the monster blocking the road.
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

[QuestScript(20069)]
public class Quest20069Script : QuestScript
{
	protected override void Load()
	{
		SetId(20069);
		SetName("Defeat the monsters blocking the road");
		SetDescription("Interruption of the monster blocking the road");
		SetTrack("SPossible", "ESuccess", "KATYN13_1_TO_OWLJUNIOR2_S1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 High Vubbe(s)", new KillObjective(41405, 8));

		AddDialogHook("KATYN13_1_TO_OWLJUNIOR2_S1_TRIGGER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

