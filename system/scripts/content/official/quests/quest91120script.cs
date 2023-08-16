//--- Melia Script -----------------------------------------------------------
// Left Front (2)
//--- Description -----------------------------------------------------------
// Quest to Continue Towards Left Front.
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

[QuestScript(91120)]
public class Quest91120Script : QuestScript
{
	protected override void Load()
	{
		SetId(91120);
		SetName("Left Front (2)");
		SetDescription("Continue Towards Left Front");
		SetTrack("SProgress", "ESuccess", "EP14_1_FCASTLE5_MQ_4_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_3"));
		AddPrerequisite(new LevelPrerequisite(468));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29952));

		AddDialogHook("EP14_1_FCASTLE5_MQ_4_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_4_HIDDEN", "BeforeEnd", BeforeEnd);
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
		character.Quests.Start("EP14_1_FCASTLE5_MQ_5");
	}
}

