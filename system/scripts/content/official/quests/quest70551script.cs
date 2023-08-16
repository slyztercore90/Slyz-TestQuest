//--- Melia Script -----------------------------------------------------------
// The true culprit
//--- Description -----------------------------------------------------------
// Quest to Moving to Mova Wilderness with Monk Dorma.
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

[QuestScript(70551)]
public class Quest70551Script : QuestScript
{
	protected override void Load()
	{
		SetId(70551);
		SetName("The true culprit");
		SetDescription("Moving to Mova Wilderness with Monk Dorma");
		SetTrack("SPossible", "ESuccess", "SCR_PILGRIM41_4_SQ12_TRACKSTART", "None");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ11"));
		AddPrerequisite(new LevelPrerequisite(265));

		AddObjective("kill0", "Kill 3 Brown Nuka(s)", new KillObjective(57986, 3));

		AddDialogHook("PILGRIM414_SQ_12", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("PILGRIM41_4_SQ13");
	}
}

