//--- Melia Script -----------------------------------------------------------
// Beast's End(1)
//--- Description -----------------------------------------------------------
// Quest to Pursuing the beast.
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

[QuestScript(70810)]
public class Quest70810Script : QuestScript
{
	protected override void Load()
	{
		SetId(70810);
		SetName("Beast's End(1)");
		SetDescription("Pursuing the beast");
		SetTrack("SPossible", "ESuccess", "WHITETREES23_1_SQ11_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ10"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_11", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_11_1", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("WHITETREES231_SQ_11_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

