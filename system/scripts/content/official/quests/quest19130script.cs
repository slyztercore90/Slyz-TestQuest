//--- Melia Script -----------------------------------------------------------
// Complete the Mission of a Wizard [Wizard Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Wizard Master.
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

[QuestScript(19130)]
public class Quest19130Script : QuestScript
{
	protected override void Load()
	{
		SetId(19130);
		SetName("Complete the Mission of a Wizard [Wizard Advancement]");
		SetDescription("Meet the Wizard Master");
		SetTrack("SProgress", "ESuccess", "JOB_WIPYCRY5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Ironbaum", new KillObjective(57173, 1));

		AddDialogHook("MASTER_WIZARD", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_WIZARD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_WIZARD5_1_ST", "JOB_WIZARD5_1", "I'll defeat Ironbaum", "I'll come back later"))
			{
				case 1:
					await dialog.Msg("JOB_WIZARD5_1_AC");
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
			await dialog.Msg("JOB_WIZARD5_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

