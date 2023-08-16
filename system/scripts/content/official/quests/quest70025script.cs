//--- Melia Script -----------------------------------------------------------
// Old Seeds (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Druid Martinek.
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

[QuestScript(70025)]
public class Quest70025Script : QuestScript
{
	protected override void Load()
	{
		SetId(70025);
		SetName("Old Seeds (2)");
		SetDescription("Talk to Druid Martinek");

		AddPrerequisite(new CompletedPrerequisite("FARM49_2_MQ05"));
		AddPrerequisite(new LevelPrerequisite(152));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 4408));

		AddDialogHook("FARM492_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FARM492_MQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM49_2_MQ_06_1", "FARM49_2_MQ06", "I will get the water", "Tell him that it will be alright"))
			{
				case 1:
					await dialog.Msg("FARM49_2_MQ_06_2");
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
			if (character.Inventory.HasItem("FARM49_2_MQ06_ITEM2", 1))
			{
				character.Inventory.RemoveItem("FARM49_2_MQ06_ITEM2", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("FARM49_2_MQ_06_5");
				// Func/SCR_FARM492_MQ_06_COMPLETE;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FARM49_2_MQ07");
	}
}

