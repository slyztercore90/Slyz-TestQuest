//--- Melia Script -----------------------------------------------------------
// Complete the Mission of an Alchemist [Alchemist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet Vaidotas.
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

[QuestScript(19230)]
public class Quest19230Script : QuestScript
{
	protected override void Load()
	{
		SetId(19230);
		SetName("Complete the Mission of an Alchemist [Alchemist Advancement]");
		SetDescription("Meet Vaidotas");
		SetTrack("SProgress", "ESuccess", "JOB_SPYLIAL5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(57174, 1));

		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_ALCHE_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ALCHEMIST5_1_ST", "JOB_ALCHEMIST5_1", "I'll take the test", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_ALCHEMIST5_1_AC");
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
			await dialog.Msg("JOB_ALCHEMIST5_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

