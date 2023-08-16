//--- Melia Script -----------------------------------------------------------
// Ingredient for Maximizing the Effect
//--- Description -----------------------------------------------------------
// Quest to Talk to Leonardas.
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

[QuestScript(72123)]
public class Quest72123Script : QuestScript
{
	protected override void Load()
	{
		SetId(72123);
		SetName("Ingredient for Maximizing the Effect");
		SetDescription("Talk to Leonardas");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ08"));
		AddPrerequisite(new LevelPrerequisite(336));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_LEONARDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE262_SQ09_DLG01", "F_3CMLAKE262_SQ09", "I'll go find it.", "Let's look for other ingredients."))
			{
				case 1:
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
			if (character.Inventory.HasItem("3CMLAKE262_SQ09_ITEM", 12))
			{
				character.Inventory.RemoveItem("3CMLAKE262_SQ09_ITEM", 12);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("3CMLAKE262_SQ09_DLG03");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

