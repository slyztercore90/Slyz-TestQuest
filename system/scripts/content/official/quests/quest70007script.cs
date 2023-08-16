//--- Melia Script -----------------------------------------------------------
// Weeding
//--- Description -----------------------------------------------------------
// Quest to Talk to Farmer Darcy.
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

[QuestScript(70007)]
public class Quest70007Script : QuestScript
{
	protected override void Load()
	{
		SetId(70007);
		SetName("Weeding");
		SetDescription("Talk to Farmer Darcy");

		AddPrerequisite(new CompletedPrerequisite("FARM49_1_SQ01"));
		AddPrerequisite(new LevelPrerequisite(149));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_1_SQ_02_1", "FARM49_1_SQ02", "I will get rid of the dandelions", "Leave since you are busy"))
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
			await dialog.Msg("FARM49_1_SQ_02_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

