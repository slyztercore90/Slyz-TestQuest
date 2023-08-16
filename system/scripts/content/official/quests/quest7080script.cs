//--- Melia Script -----------------------------------------------------------
// Interference of Necroventer
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Sculpture of Forecasts.
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

[QuestScript(7080)]
public class Quest7080Script : QuestScript
{
	protected override void Load()
	{
		SetId(7080);
		SetName("Interference of Necroventer");
		SetDescription("Talk to the Owl Sculpture of Forecasts");
		SetTrack("SProgress", "ESuccess", "PRE_KATYN18_MQ_16_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_29"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(57065, 1));

		AddDialogHook("KATYN18_MAIN_OWL_3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_MAIN_OWL_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_BOSS_KILL_select1", "KATYN18_BOSS_KILL", "Defeat Necroventer", "Cancel"))
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
			await dialog.Msg("KATYN18_BOSS_KILL_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

