//--- Melia Script -----------------------------------------------------------
// Still Needs Memory [Bokor Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Meet the Krivis Master.
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

[QuestScript(17410)]
public class Quest17410Script : QuestScript
{
	protected override void Load()
	{
		SetId(17410);
		SetName("Still Needs Memory [Bokor Advancement] (4)");
		SetDescription("Meet the Krivis Master");
		SetTrack("SProgress", "ESuccess", "JOB_BOCOR4_4_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("JOB_BOCOR4_3"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Tutu", new KillObjective(57161, 1));

		AddDialogHook("MASTER_KRIWI", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_BOCOR4_4_ST", "JOB_BOCOR4_4", "I will defeat Tutu", "Give me some time to prepare"))
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
			await dialog.Msg("JOB_BOCOR4_4_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

