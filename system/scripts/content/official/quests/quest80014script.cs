//--- Melia Script -----------------------------------------------------------
// Carlyle's Test (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Carlyle's Spirit.
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

[QuestScript(80014)]
public class Quest80014Script : QuestScript
{
	protected override void Load()
	{
		SetId(80014);
		SetName("Carlyle's Test (2)");
		SetDescription("Talk to Carlyle's Spirit");
		SetTrack("SPossible", "ESuccess", "CATACOMB_33_2_SQ_07_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_2_SQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new ItemPrerequisite("CATACOMB_33_2_SQ_SYMBOL", -100));

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(58155, 1));

		AddReward(new ExpReward(274320, 274320));
		AddReward(new ItemReward("expCard5", 6));
		AddReward(new ItemReward("Vis", 1406));

		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_2_KARLYLE", "BeforeEnd", BeforeEnd);
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

