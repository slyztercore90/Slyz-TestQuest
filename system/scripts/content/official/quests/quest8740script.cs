//--- Melia Script -----------------------------------------------------------
// Recruiting Challenger [Schwartzer Reiter Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Schwarzer Reiter Master.
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

[QuestScript(8740)]
public class Quest8740Script : QuestScript
{
	protected override void Load()
	{
		SetId(8740);
		SetName("Recruiting Challenger [Schwartzer Reiter Advancement]");
		SetDescription("Call of the Schwarzer Reiter Master");
		SetTrack("SProgress", "ESuccess", "JOB_SCOUT5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(57185, 1));

		AddReward(new ItemReward("PST01_104", 1));

		AddDialogHook("MASTER_SCHWARZEREITER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SCHWARZEREITER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_SCHWARZEREITER5_1_01", "JOB_SCHWARZEREITER5_1", "What should I do?", "I'll wait a little bit"))
			{
				case 1:
					await dialog.Msg("JOB_SCHWARZEREITER5_1_02");
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
			await dialog.Msg("JOB_SCHWARZEREITER_03");
			dialog.AddonMessage("NOTICE_Dm_Clear", "If you don't have a Velheider, you can adopt one for free at the Companion Trader!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

