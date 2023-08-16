//--- Melia Script -----------------------------------------------------------
// A Powerful Arrow (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Fletcher Voleta.
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

[QuestScript(80289)]
public class Quest80289Script : QuestScript
{
	protected override void Load()
	{
		SetId(80289);
		SetName("A Powerful Arrow (3)");
		SetDescription("Talk to Fletcher Voleta");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(370));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_87_MQ_05_ST", "F_3CMLAKE_87_MQ_05", "I'll gather them for you.", "I've never heard of it before."))
			{
				case 1:
					await dialog.Msg("F_3CMLAKE_87_MQ_05_AFST");
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
			if (character.Inventory.HasItem("F_3CMLAKE87_MQ5_ITEM", 3))
			{
				character.Inventory.RemoveItem("F_3CMLAKE87_MQ5_ITEM", 3);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("F_3CMLAKE_87_MQ_05_SU");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

