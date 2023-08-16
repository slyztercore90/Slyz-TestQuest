//--- Melia Script -----------------------------------------------------------
// Finding a Cure for the Epidemic (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jugrinas.
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

[QuestScript(30275)]
public class Quest30275Script : QuestScript
{
	protected override void Load()
	{
		SetId(30275);
		SetName("Finding a Cure for the Epidemic (1)");
		SetDescription("Talk to Jugrinas");

		AddPrerequisite(new CompletedPrerequisite("WTREES_21_2_SQ_1"));
		AddPrerequisite(new LevelPrerequisite(322));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15134));

		AddDialogHook("WTREES_21_2_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("WTREES_21_2_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WTREES_21_2_SQ_2_select", "WTREES_21_2_SQ_2", "I'll help you in place of Cicas.", "That's too bad."))
			{
				case 1:
					await dialog.Msg("WTREES_21_2_SQ_2_agree");
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
			if (character.Inventory.HasItem("WTREES_21_2_SQ_2_ITEM", 6))
			{
				character.Inventory.RemoveItem("WTREES_21_2_SQ_2_ITEM", 6);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("WTREES_21_2_SQ_2_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

