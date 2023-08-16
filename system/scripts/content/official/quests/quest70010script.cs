//--- Melia Script -----------------------------------------------------------
// The Klaipeda Investigation
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigator Monahan.
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

[QuestScript(70010)]
public class Quest70010Script : QuestScript
{
	protected override void Load()
	{
		SetId(70010);
		SetName("The Klaipeda Investigation");
		SetDescription("Talk with Investigator Monahan");

		AddPrerequisite(new LevelPrerequisite(149));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_1_SQ_05_1", "FARM49_1_SQ05", "Sure, I'll help", "Tell him to get help from other people"))
			{
				case 1:
					await dialog.Msg("FARM49_1_SQ_05_2");
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
			if (character.Inventory.HasItem("FARM49_1_SQ05_ITEM", 9))
			{
				character.Inventory.RemoveItem("FARM49_1_SQ05_ITEM", 9);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FARM49_1_SQ_05_4");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

