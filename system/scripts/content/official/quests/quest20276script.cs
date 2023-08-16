//--- Melia Script -----------------------------------------------------------
// The Unopened Portal
//--- Description -----------------------------------------------------------
// Quest to Talk to the Old Man of Andale Village.
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

[QuestScript(20276)]
public class Quest20276Script : QuestScript
{
	protected override void Load()
	{
		SetId(20276);
		SetName("The Unopened Portal");
		SetDescription("Talk to the Old Man of Andale Village");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ04"));
		AddPrerequisite(new LevelPrerequisite(49));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("HUEVILLAGE_58_2_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_2_MQ02_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("HUEVILLAGE_58_2_MQ01_select", "HUEVILLAGE_58_2_MQ01", "I'll meet the priest", "I'm busy"))
			{
				case 1:
					await dialog.Msg("HUEVILLAGE_58_2_MQ01_select_Q");
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
			if (character.Inventory.HasItem("HUEVILLAGE_58_2_MQ01_ITEM1", 5))
			{
				character.Inventory.RemoveItem("HUEVILLAGE_58_2_MQ01_ITEM1", 5);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("HUEVILLAGE_58_2_MQ01_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_2_MQ02");
	}
}

