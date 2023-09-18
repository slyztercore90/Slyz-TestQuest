//--- Melia Script -----------------------------------------------------------
// Pharmacist's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pharmacist Lady.
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

[QuestScript(40051)]
public class Quest40051Script : QuestScript
{
	protected override void Load()
	{
		SetId(40051);
		SetName("Pharmacist's Favor (2)");
		SetDescription("Talk to the Pharmacist Lady");

		AddPrerequisite(new LevelPrerequisite(11));
		AddPrerequisite(new CompletedPrerequisite("SOUT_Q_20"));

		AddReward(new ItemReward("Drug_HP1_Q", 3));

		AddDialogHook("SOUT_PHARMACY", "BeforeStart", BeforeStart);
		AddDialogHook("SOUT_PHARMACY", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("SOUT_Q_21_ST", "SOUT_Q_21", "I'll get it. ", "Decline"))
		{
			case 1:
				await dialog.Msg("SOUT_Q_21_AC");
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

		if (character.Inventory.HasItem("misc_0010", 5) && character.Inventory.HasItem("misc_0001", 5))
		{
			character.Inventory.RemoveItem("misc_0010", 5);
			character.Inventory.RemoveItem("misc_0001", 5);
			await dialog.Msg("SOUT_Q_21_COMP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

