//--- Melia Script -----------------------------------------------------------
// Power Within the Bee Tree Branch
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Raeli.
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

[QuestScript(16410)]
public class Quest16410Script : QuestScript
{
	protected override void Load()
	{
		SetId(16410);
		SetName("Power Within the Bee Tree Branch");
		SetDescription("Talk with Priest Raeli");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_2_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(166));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4980));

		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_2_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_46_2_MQ_02_select", "SIAULIAI_46_2_MQ_02", "I will collect the ashes", "Decline"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_46_2_MQ_02_start_prog");
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
			if (character.Inventory.HasItem("SIAULIAI_46_2_MQ_02_ITEM", 5))
			{
				character.Inventory.RemoveItem("SIAULIAI_46_2_MQ_02_ITEM", 5);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("SIAULIAI_46_2_MQ_02_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_2_MQ_03");
	}
}

