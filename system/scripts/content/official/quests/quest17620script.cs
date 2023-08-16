//--- Melia Script -----------------------------------------------------------
// Activities of a Cryomancer [Cryomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(17620)]
public class Quest17620Script : QuestScript
{
	protected override void Load()
	{
		SetId(17620);
		SetName("Activities of a Cryomancer [Cryomancer Advancement]");
		SetDescription("Talk to the Cryomancer Master");
		SetTrack("SProgress", "ESuccess", "JOB_CRYOMANCER4_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Mushcaria", new KillObjective(57165, 1));

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_CRYOMANCER4_1_select", "JOB_CRYOMANCER4_1", "I will get rid of the Mushcaria", "That sounds dangerous"))
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
			await dialog.Msg("JOB_CRYOMANCER4_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

