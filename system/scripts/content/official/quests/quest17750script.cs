//--- Melia Script -----------------------------------------------------------
// Qualifications of a Commander [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Submaster.
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

[QuestScript(17750)]
public class Quest17750Script : QuestScript
{
	protected override void Load()
	{
		SetId(17750);
		SetName("Qualifications of a Commander [Rodelero Advancement]");
		SetDescription("Talk to the Rodelero Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(57189, 1));

		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_RODELERO5_1_select", "JOB_RODELERO5_1", "I will try", "I don't need it"))
			{
				case 1:
					await dialog.Msg("JOB_RODELERO5_1_AG");
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
			await dialog.Msg("JOB_RODELERO5_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

