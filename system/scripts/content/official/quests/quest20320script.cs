//--- Melia Script -----------------------------------------------------------
// For the Pilgrim (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Alisha.
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

[QuestScript(20320)]
public class Quest20320Script : QuestScript
{
	protected override void Load()
	{
		SetId(20320);
		SetName("For the Pilgrim (2)");
		SetDescription("Talk to Priest Alisha");

		AddPrerequisite(new CompletedPrerequisite("PILGRIMROAD55_SQ01"));
		AddPrerequisite(new LevelPrerequisite(143));

		AddObjective("collect0", "Collect 20 Meat(s)", new CollectItemObjective("PILGRIMROAD55_SQ02_ITEM", 20));
		AddDrop("PILGRIMROAD55_SQ02_ITEM", 10f, "InfroHoglan_red");

		AddReward(new ExpReward(852900, 852900));
		AddReward(new ItemReward("expCard8", 4));
		AddReward(new ItemReward("Vis", 3718));

		AddDialogHook("PILGRIMROAD55_SQ02", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIMROAD55_SQ02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIMROAD55_SQ02_select01", "PILGRIMROAD55_SQ02", "I will get some meat", "I'll get going now"))
			{
				case 1:
					await dialog.Msg("PILGRIMROAD55_SQ02_startnpc01");
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
			if (character.Inventory.HasItem("PILGRIMROAD55_SQ02_ITEM", 20))
			{
				character.Inventory.RemoveItem("PILGRIMROAD55_SQ02_ITEM", 20);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PILGRIMROAD55_SQ02_succ01");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

