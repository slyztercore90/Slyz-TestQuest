//--- Melia Script -----------------------------------------------------------
// The Disappearance (2)
//--- Description -----------------------------------------------------------
// Quest to Search the spot where the disappearances took place.
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

[QuestScript(50034)]
public class Quest50034Script : QuestScript
{
	protected override void Load()
	{
		SetId(50034);
		SetName("The Disappearance (2)");
		SetDescription("Search the spot where the disappearances took place");
		SetTrack("SProgress", "ESuccess", "PARTY_Q_040_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_040"));
		AddPrerequisite(new LevelPrerequisite(100));

		AddObjective("kill0", "Kill 6 Paladin Follower A1(s) or Paladin Follower A3(s)", new KillObjective(6, 11281, 11283));

		AddDialogHook("PARTY_Q41_ORB", "BeforeStart", BeforeStart);
		AddDialogHook("KLAIPEDA_MAYER", "BeforeEnd", BeforeEnd);
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
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("PARTY_Q_041_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

