//--- Melia Script -----------------------------------------------------------
// Ruined Brewery
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

[QuestScript(16020)]
public class Quest16020Script : QuestScript
{
	protected override void Load()
	{
		SetId(16020);
		SetName("Ruined Brewery");
		SetDescription("Talk to Villager Darren");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(160));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_4_MQ04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_46_4_MQ_03_select", "SIAULIAI_46_4_MQ_03", "I'll help", "I'll get going then"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_46_4_MQ_03_start_prog");
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
			if (character.Inventory.HasItem("SIAULIAI_46_4_MQ_03_ITEM", 4))
			{
				character.Inventory.RemoveItem("SIAULIAI_46_4_MQ_03_ITEM", 4);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("SIAULIAI_46_4_MQ_03_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_4_MQ_04");
	}
}

