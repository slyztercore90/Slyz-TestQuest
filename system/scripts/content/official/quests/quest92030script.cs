//--- Melia Script -----------------------------------------------------------
// Extinct Mirtinas (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Baiga.
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

[QuestScript(92030)]
public class Quest92030Script : QuestScript
{
	protected override void Load()
	{
		SetId(92030);
		SetName("Extinct Mirtinas (3)");
		SetDescription("Talk to Baiga");
		SetTrack("SPossible", "ESuccess", "EP13_F_SIAULIAI_5_MQ_04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(458));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_5_BAIGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_GODDESS_LADA_ISA", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EP13_F_SIAULIAI_5_MQ_04_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

