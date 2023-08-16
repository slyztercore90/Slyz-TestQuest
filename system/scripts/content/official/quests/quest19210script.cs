//--- Melia Script -----------------------------------------------------------
// Complete the Mission of a Chronomancer [Chronomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Chronomancer Master.
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

[QuestScript(19210)]
public class Quest19210Script : QuestScript
{
	protected override void Load()
	{
		SetId(19210);
		SetName("Complete the Mission of a Chronomancer [Chronomancer Advancement]");
		SetDescription("Meet the Chronomancer Master");
		SetTrack("SProgress", "ESuccess", "JOB_CHROSOC5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(57152, 1));

		AddDialogHook("MASTER_CHRONO", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_CHRONO5_1_ST", "JOB_CHRONO5_1", "I'll prove myself through a test", "I will get it again later"))
			{
				case 1:
					await dialog.Msg("JOB_CHRONO5_1_AC");
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
			await dialog.Msg("JOB_CHRONO5_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

