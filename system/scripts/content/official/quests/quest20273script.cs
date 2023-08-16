//--- Melia Script -----------------------------------------------------------
// Purify Kvailas Forest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Kazis.
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

[QuestScript(20273)]
public class Quest20273Script : QuestScript
{
	protected override void Load()
	{
		SetId(20273);
		SetName("Purify Kvailas Forest (2)");
		SetDescription("Talk to Believer Kazis");
		SetTrack("SProgress", "ESuccess", "THORN21_MQ06_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 1 Honeypin", new KillObjective(41242, 1));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN21_MQ06_select01", "THORN21_MQ06", "I'll help the purifying job", "It's dangerous, give up"))
			{
				case 1:
					await dialog.Msg("THORN21_MQ06_startnpc01");
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
			await dialog.Msg("THORN21_MQ06_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

