//--- Melia Script -----------------------------------------------------------
// The Right Man in the Right Place 
//--- Description -----------------------------------------------------------
// Quest to Move to the Handicraft Workshop Distance.
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

[QuestScript(91098)]
public class Quest91098Script : QuestScript
{
	protected override void Load()
	{
		SetId(91098);
		SetName("The Right Man in the Right Place ");
		SetDescription("Move to the Handicraft Workshop Distance");
		SetTrack("SPossible", "ESuccess", "EP14_1_FCASTLE2_MQ_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE2_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(462));

		AddReward(new ExpReward(1046153856, 1046153856));
		AddReward(new ItemReward("Vis", 29106));

		AddDialogHook("EP14_1_FCASTLE2_MQ_7_HIDDEN", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE2_MQ_7_NPC1", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EP14_1_FCASTLE2_MQ_7_CNPC_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

