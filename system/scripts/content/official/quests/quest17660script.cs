//--- Melia Script -----------------------------------------------------------
// An Important Test [Elementalist]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elementalist Submaster.
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

[QuestScript(17660)]
public class Quest17660Script : QuestScript
{
	protected override void Load()
	{
		SetId(17660);
		SetName("An Important Test [Elementalist]");
		SetDescription("Talk to the Elementalist Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_WARLOCK4_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(57169, 1));

		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_WARLOCK4_1_select", "JOB_WARLOCK4_1", "I will defeat the Reaverpede", "Decline since it seems too dangerous"))
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
			await dialog.Msg("JOB_WARLOCK4_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

