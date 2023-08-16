//--- Melia Script -----------------------------------------------------------
// Complete the Pyromancer's Mission [Pyromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Pyromancer Master.
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

[QuestScript(19140)]
public class Quest19140Script : QuestScript
{
	protected override void Load()
	{
		SetId(19140);
		SetName("Complete the Pyromancer's Mission [Pyromancer Advancement]");
		SetDescription("Meet the Pyromancer Master");
		SetTrack("SProgress", "ESuccess", "JOB_WIPYCRY5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Ironbaum", new KillObjective(57173, 1));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PYROMANCER5_1_ST", "JOB_PYROMANCER5_1", "Alright, I'll help you", "Decline"))
			{
				case 1:
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
			await dialog.Msg("JOB_PYROMANCER5_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

