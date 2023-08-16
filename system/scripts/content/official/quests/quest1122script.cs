//--- Melia Script -----------------------------------------------------------
// Fedimian Completionist [Archer Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Master.
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

[QuestScript(1122)]
public class Quest1122Script : QuestScript
{
	protected override void Load()
	{
		SetId(1122);
		SetName("Fedimian Completionist [Archer Advancement] (2)");
		SetDescription("Talk to the Rodelero Master");
		SetTrack("SProgress", "ESuccess", "JOB_QUARREL3_2_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("JOB_ARCHER3_1"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Minotaur", new KillObjective(57153, 1));

		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ARCHER3_2_select1", "JOB_ARCHER3_2", "I will defeat it", "It sounds too dangerous"))
			{
				case 1:
					await dialog.Msg("JOB_ARCHER3_2_prog1");
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
			await dialog.Msg("JOB_ARCHER3_2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

