//--- Melia Script -----------------------------------------------------------
// A Dark Entity
//--- Description -----------------------------------------------------------
// Quest to Check the black subject on the way to the next point.
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

[QuestScript(91114)]
public class Quest91114Script : QuestScript
{
	protected override void Load()
	{
		SetId(91114);
		SetName("A Dark Entity");
		SetDescription("Check the black subject on the way to the next point");
		SetTrack("SPossible", "ESuccess", "EP14_1_FCASTLE4_MQ_6_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE4_MQ_5"));
		AddPrerequisite(new LevelPrerequisite(466));

		AddReward(new ExpReward(1046153856, 1046153856));

		AddDialogHook("EP14_1_FCASTLE4_MQ_6_NPC1", "BeforeStart", BeforeStart);
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
		character.Quests.Start("EP14_1_FCASTLE4_MQ_7");
	}
}

