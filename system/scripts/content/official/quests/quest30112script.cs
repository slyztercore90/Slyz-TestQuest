//--- Melia Script -----------------------------------------------------------
// The Master of Poison [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Wugushi Master.
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

[QuestScript(30112)]
public class Quest30112Script : QuestScript
{
	protected override void Load()
	{
		SetId(30112);
		SetName("The Master of Poison [Wugushi Advancement]");
		SetDescription("Talk to the Wugushi Master");
		SetTrack("SProgress", "ESuccess", "JOB_WUGU5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Rajatoad", new KillObjective(57184, 1));

		AddDialogHook("JOB_2_WUGUSHI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_WUGUSHI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_WUGUSHI_6_1_select", "JOB_2_WUGUSHI_6_1", "I'll accept your request", "That place is dangerous; I'll pass"))
			{
				case 1:
					await dialog.Msg("JOB_2_WUGUSHI_6_1_agree");
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
			await dialog.Msg("JOB_2_WUGUSHI_6_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

