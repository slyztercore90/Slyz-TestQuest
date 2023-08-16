//--- Melia Script -----------------------------------------------------------
// Unknown Power
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Ellie.
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

[QuestScript(70001)]
public class Quest70001Script : QuestScript
{
	protected override void Load()
	{
		SetId(70001);
		SetName("Unknown Power");
		SetDescription("Talk to Druid Ellie");

		AddPrerequisite(new CompletedPrerequisite("FARM49_1_MQ01"));
		AddPrerequisite(new LevelPrerequisite(149));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3874));

		AddDialogHook("FARM491_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("FARM491_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_1_MQ_02_1", "FARM49_1_MQ02", "Ask her if there's anything more to help", "You leave since you've helped her enough"))
			{
				case 1:
					await dialog.Msg("FARM49_1_MQ_02_2");
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
			if (character.Inventory.HasItem("FARM49_1_MQ02_ITEM1", 1) && character.Inventory.HasItem("FARM49_1_MQ02_ITEM2", 1))
			{
				character.Inventory.RemoveItem("FARM49_1_MQ02_ITEM1", 1);
				character.Inventory.RemoveItem("FARM49_1_MQ02_ITEM2", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FARM49_1_MQ_02_4");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

