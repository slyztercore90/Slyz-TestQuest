//--- Melia Script -----------------------------------------------------------
// Unfortunate Distrust
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

[QuestScript(70420)]
public class Quest70420Script : QuestScript
{
	protected override void Load()
	{
		SetId(70420);
		SetName("Unfortunate Distrust");
		SetTrack("SPossible", "ESuccess", "CASTLE65_2_MQ01_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_1_MQ06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("CASTLE652_MQ_01_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_MQ_01", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("CASTLE65_2_MQ02");
	}
}

