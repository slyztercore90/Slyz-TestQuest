//--- Melia Script -----------------------------------------------------------
// Colleague who came Earlier
//--- Description -----------------------------------------------------------
// Quest to Move to Delmore Outskirts.
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

[QuestScript(91100)]
public class Quest91100Script : QuestScript
{
	protected override void Load()
	{
		SetId(91100);
		SetName("Colleague who came Earlier");
		SetDescription("Move to Delmore Outskirts");
		SetTrack("SPossible", "ESuccess", "EP14_1_FCASTLE3_MQ_1_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(464));

		AddReward(new ExpReward(1046153856, 1046153856));

		AddDialogHook("EP14_1_FCASTLE3_MQ_1_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE3_MQ_1_NPC1", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EP14_1_FCASTLE3_MQ_1_CNPC_DLG1");
			dialog.HideNPC("EP14_1_FCASTLE3_MQ_1_HIDDEN");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

