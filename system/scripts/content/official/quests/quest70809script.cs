//--- Melia Script -----------------------------------------------------------
// To trap a beast(2)
//--- Description -----------------------------------------------------------
// Quest to .
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

[QuestScript(70809)]
public class Quest70809Script : QuestScript
{
	protected override void Load()
	{
		SetId(70809);
		SetName("To trap a beast(2)");
		SetTrack("SPossible", "ESuccess", "WHITETREES23_1_SQ10_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ09"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddDialogHook("WHITETREES231_SQ_10", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_11", "BeforeEnd", BeforeEnd);
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WHITETREES23_1_SQ11");
	}
}

