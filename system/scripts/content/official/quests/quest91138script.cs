//--- Melia Script -----------------------------------------------------------
// Ominous Red Crystal (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91138)]
public class Quest91138Script : QuestScript
{
	protected override void Load()
	{
		SetId(91138);
		SetName("Ominous Red Crystal (1)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_1_PAJAUTA1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_2_DCASTLE1_MQ_5_DLG1", "EP14_2_DCASTLE1_MQ_5", "I am ready.", "I will come after doing something else"))
			{
				case 1:
					await dialog.Msg("EP14_2_DCASTLE1_MQ_5_DLG2");
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
			if (character.Inventory.HasItem("EP14_2_DCASTLE1_MQ_5_ITEM1", 6))
			{
				character.Inventory.RemoveItem("EP14_2_DCASTLE1_MQ_5_ITEM1", 6);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP14_2_DCASTLE1_MQ_5_DLG4");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_2_DCASTLE1_MQ_6");
	}
}

