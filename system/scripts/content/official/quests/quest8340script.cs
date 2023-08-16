//--- Melia Script -----------------------------------------------------------
// Interruption of the monster blocking the road
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

[QuestScript(8340)]
public class Quest8340Script : QuestScript
{
	protected override void Load()
	{
		SetId(8340);
		SetName("Interruption of the monster blocking the road");
		SetDescription("Interruption of the monster blocking the road");
		SetTrack("SProgress", "ESuccess", "KATYN18_SUB04_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 6 Desmodus(s)", new KillObjective(11110, 6));

		AddDialogHook("KATYN18_SUB_04", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_SUB_04", "BeforeEnd", BeforeEnd);
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

