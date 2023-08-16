//--- Melia Script -----------------------------------------------------------
// Healer Lady's Worry (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Healer Lady.
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

[QuestScript(8075)]
public class Quest8075Script : QuestScript
{
	protected override void Load()
	{
		SetId(8075);
		SetName("Healer Lady's Worry (1)");
		SetDescription("Talk to the Healer Lady");
		SetTrack("SProgress", "ESuccess", "SOUT_Q_09_NEW_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(10));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 130));

		AddDialogHook("SIAULIAIOUT_HEALER_B", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_HEALER_C", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SOUT_Q_09_1", "SOUT_Q_09", "I'll bring the refugees", "Decline"))
			{
				case 1:
					await dialog.Msg("SOUT_Q_09_AC");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("SOUT_Q_09_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

