//--- Melia Script -----------------------------------------------------------
// Moses' True Feelings (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Old Man Moses.
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

[QuestScript(20244)]
public class Quest20244Script : QuestScript
{
	protected override void Load()
	{
		SetId(20244);
		SetName("Moses' True Feelings (4)");
		SetDescription("Talk to Old Man Moses");

		AddPrerequisite(new CompletedPrerequisite("REMAIN39_SQ07"));
		AddPrerequisite(new LevelPrerequisite(103));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 2472));

		AddDialogHook("REMAIN39_SQ_MOJE", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN39_SQ_MAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAIN39_SQ08_select01", "REMAIN39_SQ08", "I'll deliver it for you", "Tell him to give it to him directly"))
			{
				case 1:
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
			await dialog.Msg("REMAIN39_SQ08_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

