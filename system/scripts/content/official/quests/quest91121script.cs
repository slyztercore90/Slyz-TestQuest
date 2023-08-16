//--- Melia Script -----------------------------------------------------------
// To the Center
//--- Description -----------------------------------------------------------
// Quest to Move to the center and reinforce the General Ramin.
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

[QuestScript(91121)]
public class Quest91121Script : QuestScript
{
	protected override void Load()
	{
		SetId(91121);
		SetName("To the Center");
		SetDescription("Move to the center and reinforce the General Ramin");
		SetTrack("SProgress", "ESuccess", "EP14_1_FCASTLE5_MQ_5_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(468));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29952));

		AddDialogHook("EP14_1_FCASTLE5_MQ_5_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_5_HIDDEN", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("EP14_1_FCASTLE5_MQ_6");
	}
}

