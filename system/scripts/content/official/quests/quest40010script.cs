//--- Melia Script -----------------------------------------------------------
// Bishop's Dream of the Goddess (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Item Merchant.
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

[QuestScript(40010)]
public class Quest40010Script : QuestScript
{
	protected override void Load()
	{
		SetId(40010);
		SetName("Bishop's Dream of the Goddess (2)");
		SetDescription("Talk to the Item Merchant");

		AddPrerequisite(new CompletedPrerequisite("EAST_PREPARE"));
		AddPrerequisite(new LevelPrerequisite(1));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));

		AddDialogHook("EMILIA", "BeforeStart", BeforeStart);
		AddDialogHook("ALFONSO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EAST_PREPARE_1_ST", "EAST_PREPARE_1", "Yes, I'll drop by", "Decline"))
			{
				case 1:
					await dialog.Msg("EAST_PREPARE_1_AC");
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EAST_PREPARE_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

