//--- Melia Script -----------------------------------------------------------
// More and More
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

[QuestScript(20316)]
public class Quest20316Script : QuestScript
{
	protected override void Load()
	{
		SetId(20316);
		SetName("More and More");
		SetDescription("Talk to Priest Daram");

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_SQ04_PART2"));
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
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL54_SQ03_PART1_select01", "CHATHEDRAL54_SQ03_PART1", "Ask her how you can help", "I don't have time for that"))
			{
				case 1:
					await dialog.Msg("CHATHEDRAL54_SQ03_PART1_AG");
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("CHATHEDRAL54_SQ03_PART1_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

