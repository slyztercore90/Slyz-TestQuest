//--- Melia Script -----------------------------------------------------------
// Hidden Room
//--- Description -----------------------------------------------------------
// Quest to Inspect the Hidden Chamber.
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

[QuestScript(90094)]
public class Quest90094Script : QuestScript
{
	protected override void Load()
	{
		SetId(90094);
		SetName("Hidden Room");
		SetDescription("Inspect the Hidden Chamber");
		SetTrack("SPossible", "ESuccess", "CATACOMB_25_4_SQ_120_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_110"));
		AddPrerequisite(new LevelPrerequisite(292));

		AddObjective("kill0", "Kill 1 Specter Monarch", new KillObjective(107010, 1));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("CATACOMB_25_4_SQ_120", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

