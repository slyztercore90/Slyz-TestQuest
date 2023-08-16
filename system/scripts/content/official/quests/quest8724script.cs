//--- Melia Script -----------------------------------------------------------
// Proving Skills [Hoplite Advancement]
//--- Description -----------------------------------------------------------
// Quest to Look for the Hoplite Submaster .
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

[QuestScript(8724)]
public class Quest8724Script : QuestScript
{
	protected override void Load()
	{
		SetId(8724);
		SetName("Proving Skills [Hoplite Advancement]");
		SetDescription("Look for the Hoplite Submaster ");
		SetTrack("SProgress", "ESuccess", "JOB_HOPLITE4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Shadowgaler", new KillObjective(57158, 1));

		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HOPLITE2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HOPLITE4_1_01", "JOB_HOPLITE4_1", "I will try", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_HOPLITE4_1_AG");
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
			await dialog.Msg("JOB_HOPLITE4_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

