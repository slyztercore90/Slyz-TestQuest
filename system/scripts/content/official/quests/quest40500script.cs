//--- Melia Script -----------------------------------------------------------
// The Ramparts More Durable Than the Kingdom (1)
//--- Description -----------------------------------------------------------
// Quest to Examining the tablet.
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

[QuestScript(40500)]
public class Quest40500Script : QuestScript
{
	protected override void Load()
	{
		SetId(40500);
		SetName("The Ramparts More Durable Than the Kingdom (1)");
		SetDescription("Examining the tablet");
		SetTrack("SProgress", "ESuccess", "REMAINS37_1_SQ_020_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_011"));
		AddPrerequisite(new LevelPrerequisite(168));

		AddObjective("kill0", "Kill 11 Wendigo Shaman(s) or Wendigo Searcher(s)", new KillObjective(11, 57620, 57622));

		AddDialogHook("REMAINS37_1_MT02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

