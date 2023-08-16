//--- Melia Script -----------------------------------------------------------
// Vilna Forest: The Monsters' Purpose (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Maras.
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

[QuestScript(16200)]
public class Quest16200Script : QuestScript
{
	protected override void Load()
	{
		SetId(16200);
		SetName("Vilna Forest: The Monsters' Purpose (1)");
		SetDescription("Talk to Maras");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(163));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("SIAULIAI_46_3_MQ01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_46_3_MQ01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_46_3_MQ_01_select", "SIAULIAI_46_3_MQ_01", "I'll do it", "Reason behind hiring Revelators", "I'm not interested"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_46_3_MQ_01_PG");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("SIAULIAI_46_3_MQ_01_add");
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
			if (character.Inventory.HasItem("SIAULIAI_46_3_MQ_01_ITEM", 1))
			{
				character.Inventory.RemoveItem("SIAULIAI_46_3_MQ_01_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("SIAULIAI_46_3_MQ_01_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_46_3_MQ_02");
	}
}

