//--- Melia Script -----------------------------------------------------------
// Save the Royal Army
//--- Description -----------------------------------------------------------
// Quest to Find Pajauta in Delmore Citadel.
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

[QuestScript(91109)]
public class Quest91109Script : QuestScript
{
	protected override void Load()
	{
		SetId(91109);
		SetName("Save the Royal Army");
		SetDescription("Find Pajauta in Delmore Citadel");
		SetTrack("SPossible", "ESuccess", "EP14_1_FCASTLE4_MQ_1_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE3_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(466));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29358));

		AddDialogHook("EP14_1_FCASTLE4_MQ_1_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_F_CASTLE_4_FOLLOW_NPC", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EP14_1_FCASTLE4_MQ_1_CNPC_DLG1");
			dialog.HideNPC("EP14_1_FCASTLE4_MQ_1_HIDDEN");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

