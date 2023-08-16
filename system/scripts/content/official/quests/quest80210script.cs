//--- Melia Script -----------------------------------------------------------
// An Awful Smell (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Edward.
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

[QuestScript(80210)]
public class Quest80210Script : QuestScript
{
	protected override void Load()
	{
		SetId(80210);
		SetName("An Awful Smell (1)");
		SetDescription("Talk to Edward");

		AddPrerequisite(new CompletedPrerequisite("FARM49_1_SQ08"));
		AddPrerequisite(new LevelPrerequisite(152));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_SQ_07", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_SQ_07", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_2_SQ_07_select01", "FARM49_2_SQ07", "Alright", "That's nasty."))
			{
				case 1:
					await dialog.Msg("FARM49_2_SQ_07_agree01");
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
			await dialog.Msg("FARM49_2_SQ_07_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

