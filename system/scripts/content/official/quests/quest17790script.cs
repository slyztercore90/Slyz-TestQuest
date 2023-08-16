//--- Melia Script -----------------------------------------------------------
// Price of Danger [Doppelsoeldner Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Doppelsoeldner Master.
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

[QuestScript(17790)]
public class Quest17790Script : QuestScript
{
	protected override void Load()
	{
		SetId(17790);
		SetName("Price of Danger [Doppelsoeldner Advancement]");
		SetDescription("Talk to the Doppelsoeldner Master");
		SetTrack("SProgress", "ESuccess", "JOB_PELTASTA5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Gaigalas", new KillObjective(57188, 1));

		AddDialogHook("MASTER_DOPPELSOELDNER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_DOPPELSOELDNER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_DOPPELSOELDNER5_1_select", "JOB_DOPPELSOELDNER5_1", "I will defeat it", "It's too risky. I'll stop"))
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
			await dialog.Msg("JOB_DOPPELSOELDNER5_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

