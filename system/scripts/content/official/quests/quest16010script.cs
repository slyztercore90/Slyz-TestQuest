//--- Melia Script -----------------------------------------------------------
// It's the Honey (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Villager Darren.
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

[QuestScript(16010)]
public class Quest16010Script : QuestScript
{
	protected override void Load()
	{
		SetId(16010);
		SetName("It's the Honey (2)");
		SetDescription("Talk to Villager Darren");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(160));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_4_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_46_4_MQ_02_select", "SIAULIAI_46_4_MQ_02", "I'll take a look", "About the monsters and bee farming", "I've done enough so just go my way"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_46_4_MQ_02_start_prog");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("SIAULIAI_46_4_MQ_02_ADD");
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
			if (character.Inventory.HasItem("SIAULIAI_46_4_MQ_02_ITEM", 1))
			{
				character.Inventory.RemoveItem("SIAULIAI_46_4_MQ_02_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("SIAULIAI_46_4_MQ_02_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_4_MQ_03");
	}
}

