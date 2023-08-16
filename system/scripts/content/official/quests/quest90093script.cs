//--- Melia Script -----------------------------------------------------------
// Nobody Expects the Inquisition (3)
//--- Description -----------------------------------------------------------
// Quest to Drive Away the Heretics At Tymeris Temple.
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

[QuestScript(90093)]
public class Quest90093Script : QuestScript
{
	protected override void Load()
	{
		SetId(90093);
		SetName("Nobody Expects the Inquisition (3)");
		SetDescription("Drive Away the Heretics At Tymeris Temple");
		SetTrack("SPossible", "ESuccess", "CATACOMB_25_4_SQ_110_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_100"));
		AddPrerequisite(new LevelPrerequisite(292));

		AddObjective("kill0", "Kill 10 Yellow Pag Clamper(s)", new KillObjective(58501, 10));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_110", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_LAIMIS", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("CATACOMB_25_4_SQ_110_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

