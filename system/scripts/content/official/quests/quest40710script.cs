//--- Melia Script -----------------------------------------------------------
// Rust Remover (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Justas.
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

[QuestScript(40710)]
public class Quest40710Script : QuestScript
{
	protected override void Load()
	{
		SetId(40710);
		SetName("Rust Remover (1)");
		SetDescription("Talk to Justas");

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_3_SQ_042"));
		AddPrerequisite(new LevelPrerequisite(176));

		AddObjective("collect0", "Collect 6 Hallowventor Magician Inner Core(s)", new CollectItemObjective("REMAINS37_3_SQ_050_ITEM_1", 6));
		AddDrop("REMAINS37_3_SQ_050_ITEM_1", 10f, "Hallowventor_mage");

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_3_JUSTAS_AFTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS37_3_SQ_050_ST", "REMAINS37_3_SQ_050", "Ask him how you can help", "The reason to corrode it", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("REMAINS37_3_SQ_050_AC");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("REMAINS37_3_SQ_050_AD");
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
			if (character.Inventory.HasItem("REMAINS37_3_SQ_050_ITEM_1", 6))
			{
				character.Inventory.RemoveItem("REMAINS37_3_SQ_050_ITEM_1", 6);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("REMAINS37_3_SQ_050_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("REMAINS37_3_SQ_060");
	}
}

