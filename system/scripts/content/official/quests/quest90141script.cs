//--- Melia Script -----------------------------------------------------------
// Inspect the Perimeter (2)
//--- Description -----------------------------------------------------------
// Quest to Look around the Jonael Memorial.
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

[QuestScript(90141)]
public class Quest90141Script : QuestScript
{
	protected override void Load()
	{
		SetId(90141);
		SetName("Inspect the Perimeter (2)");
		SetDescription("Look around the Jonael Memorial");
		SetTrack("SPossible", "ESuccess", "F_DCAPITAL_20_6_SQ_20_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(295));

		AddDialogHook("DCAPITAL_20_6_SQ_10_ENT", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

