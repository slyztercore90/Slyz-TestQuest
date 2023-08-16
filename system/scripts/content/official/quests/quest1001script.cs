//--- Melia Script -----------------------------------------------------------
// Talk to Knight Titas (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sentinel.
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

[QuestScript(1001)]
public class Quest1001Script : QuestScript
{
	protected override void Load()
	{
		SetId(1001);
		SetName("Talk to Knight Titas (1)");
		SetDescription("Talk to the Sentinel");
		SetTrack("SProgress", "ESuccess", "SIAU_WEST_START_TRACK", 1000);

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("SIAUL_WEST_MEET_TITAS_AUTO", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

