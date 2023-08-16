//--- Melia Script -----------------------------------------------------------
// To the Left (2)
//--- Description -----------------------------------------------------------
// Quest to Corner Lunatic Marnox to the next point.
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

[QuestScript(91068)]
public class Quest91068Script : QuestScript
{
	protected override void Load()
	{
		SetId(91068);
		SetName("To the Left (2)");
		SetDescription("Corner Lunatic Marnox to the next point");
		SetTrack("SProgress", "ESuccess", "EP13_2_DPRISON3_MQ_5_TRACK_1", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON3_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddDialogHook("EP13_2_DPRISON3_MQ_NPC_L_2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

