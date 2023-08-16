//--- Melia Script -----------------------------------------------------------
// Healer Lady's Worry (3)
//--- Description -----------------------------------------------------------
// Quest to Listen to the Healer Lady's request.
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

[QuestScript(8347)]
public class Quest8347Script : QuestScript
{
	protected override void Load()
	{
		SetId(8347);
		SetName("Healer Lady's Worry (3)");
		SetDescription("Listen to the Healer Lady's request");
		SetTrack("SProgress", "ESuccess", "SOUT_SUDD_PREBOSS", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_10"));
		AddPrerequisite(new LevelPrerequisite(10));

		AddObjective("kill0", "Kill 1 Chafer", new KillObjective(41320, 1));

		AddReward(new ExpReward(1500, 1500));
		AddReward(new ItemReward("expCard1", 3));
		AddReward(new ItemReward("TreasureboxKey2", 1));
		AddReward(new ItemReward("Vis", 130));

		AddDialogHook("SIAULIAIOUT_HEALER_B", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_HEALER_B", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SOUT_SUDD_PREBOSS_ST", "SOUT_SUDD_PREBOSS", "Okay, I'll go look around again", "That would not happen."))
			{
				case 1:
					await dialog.Msg("SOUT_SUDD_PREBOSS_AC");
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
			await dialog.Msg("SOUT_SUDD_PREBOSS_COMP");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("SIAULIAIOUT_HEALER_B");
			dialog.HideNPC("SIAULIAIOUT_RETUA");
			dialog.UnHideNPC("SOUT_PHARMACY");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

