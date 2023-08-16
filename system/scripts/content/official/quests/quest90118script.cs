//--- Melia Script -----------------------------------------------------------
// Losing Battle
//--- Description -----------------------------------------------------------
// Quest to Inspect the Suspicious Looking Rock.
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

[QuestScript(90118)]
public class Quest90118Script : QuestScript
{
	protected override void Load()
	{
		SetId(90118);
		SetName("Losing Battle");
		SetDescription("Inspect the Suspicious Looking Rock");
		SetTrack("SPossible", "ESuccess", "MAPLE_25_1_SQ_110_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(282));

		AddObjective("kill0", "Kill 1 Velorchard", new KillObjective(107009, 1));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11844));

		AddDialogHook("MAPLE_25_1_SQ_110", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_1_SQ_110", "BeforeEnd", BeforeEnd);
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
			dialog.HideNPC("MAPLE_25_1_ROCK");
			dialog.HideNPC("MAPLE_25_1_SQ_110");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

