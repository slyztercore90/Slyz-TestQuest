//--- Melia Script -----------------------------------------------------------
// Meeting the Anastospa
//--- Description -----------------------------------------------------------
// Quest to Find the Anastospa Camping Ground.
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

[QuestScript(41090)]
public class Quest41090Script : QuestScript
{
	protected override void Load()
	{
		SetId(41090);
		SetName("Meeting the Anastospa");
		SetDescription("Find the Anastospa Camping Ground");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_080"));
		AddPrerequisite(new LevelPrerequisite(106));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM_36_2_SQ_090_ST", "PILGRIM_36_2_SQ_090", "I'll help", "Please wait until it finishes"))
			{
				case 1:
					await dialog.Msg("PILGRIM_36_2_SQ_090_AC");
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
			if (character.Inventory.HasItem("PILGRIM_36_2_SQ_090_ITEM_2", 50))
			{
				character.Inventory.RemoveItem("PILGRIM_36_2_SQ_090_ITEM_2", 50);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PILGRIM_36_2_SQ_090_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

