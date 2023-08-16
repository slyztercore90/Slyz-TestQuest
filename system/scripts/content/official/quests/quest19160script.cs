//--- Melia Script -----------------------------------------------------------
// Complete the Psychokino 's Mission [Psychokino Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Psychokino Master.
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

[QuestScript(19160)]
public class Quest19160Script : QuestScript
{
	protected override void Load()
	{
		SetId(19160);
		SetName("Complete the Psychokino 's Mission [Psychokino Advancement]");
		SetDescription("Meet the Psychokino Master");
		SetTrack("SProgress", "ESuccess", "JOB_SPYLIAL5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(57174, 1));

		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_PSYCHOKINESIST2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PSYCHOKINESIST5_1_ST", "JOB_PSYCHOKINESIST5_1", "I'll complete the mission for you", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_PSYCHOKINESIST5_1_AC");
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
			await dialog.Msg("JOB_PSYCHOKINESIST5_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

