//--- Melia Script -----------------------------------------------------------
// Investigate the Miners' Village
//--- Description -----------------------------------------------------------
// Quest to Arrive at the Miners' Village.
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

[QuestScript(8067)]
public class Quest8067Script : QuestScript
{
	protected override void Load()
	{
		SetId(8067);
		SetName("Investigate the Miners' Village");
		SetDescription("Arrive at the Miners' Village");
		SetTrack("SProgress", "ESuccess", "SIAU_OUT_Q1_TRACK", 3000);

		AddPrerequisite(new CompletedPrerequisite("SIAUL_EAST_REQUEST7"));
		AddPrerequisite(new LevelPrerequisite(10));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));

		AddDialogHook("SIAULIAIOUT_Q01", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("SOUT_Q_01_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

