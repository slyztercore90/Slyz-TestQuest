//--- Melia Script -----------------------------------------------------------
// Convincing Lord Joquvas(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Roberta.
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

[QuestScript(70828)]
public class Quest70828Script : QuestScript
{
	protected override void Load()
	{
		SetId(70828);
		SetName("Convincing Lord Joquvas(3)");
		SetDescription("Talk to Roberta");

		AddPrerequisite(new LevelPrerequisite(319));
		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ08"));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14674));

		AddDialogHook("MAPLE232_SQ_07_2", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_07_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("MAPLE232_SQ_09_start", "MAPLE23_2_SQ09", "Ask what you need to look for", "Say that he must make a promise before you agree to do anything"))
		{
			case 1:
				await dialog.Msg("MAPLE232_SQ_09_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("MAPLE23_2_SQ09_ITEM", 1))
		{
			character.Inventory.RemoveItem("MAPLE23_2_SQ09_ITEM", 1);
			await dialog.Msg("MAPLE232_SQ_09_succ");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

