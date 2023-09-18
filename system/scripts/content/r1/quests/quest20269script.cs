//--- Melia Script -----------------------------------------------------------
// Purify Kvailas Forest (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Samantha.
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

[QuestScript(20269)]
public class Quest20269Script : QuestScript
{
	protected override void Load()
	{
		SetId(20269);
		SetName("Purify Kvailas Forest (1)");
		SetDescription("Talk to Believer Samantha");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "THORN21_MQ02_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(64));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BELIEVER02", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("THORN21_MQ02_select01", "THORN21_MQ02", "I will protect the altar from the monsters", "I don't know"))
		{
			case 1:
				await dialog.Msg("THORN21_MQ02_startnpc01");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("THORN21_MQ02_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

