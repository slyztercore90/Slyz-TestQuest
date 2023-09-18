//--- Melia Script -----------------------------------------------------------
// Tremendous Effects
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Daram.
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

[QuestScript(20317)]
public class Quest20317Script : QuestScript
{
	protected override void Load()
	{
		SetId(20317);
		SetName("Tremendous Effects");
		SetDescription("Talk to Priest Daram");

		AddPrerequisite(new LevelPrerequisite(140));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3640));

		AddDialogHook("CHATHEDRAL54_SQ01_PART1", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL54_SQ01_PART1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("CHATHEDRAL54_SQ04_PART2_select01", "CHATHEDRAL54_SQ04_PART2", "I will test it out", "I don't have time for that"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("CHATHEDRAL54_SQ04_PART2_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

