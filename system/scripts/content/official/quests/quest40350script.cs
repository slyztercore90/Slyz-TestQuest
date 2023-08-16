//--- Melia Script -----------------------------------------------------------
// Positive Evidence (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Varas.
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

[QuestScript(40350)]
public class Quest40350Script : QuestScript
{
	protected override void Load()
	{
		SetId(40350);
		SetName("Positive Evidence (2)");
		SetDescription("Talk to Varas");

		AddPrerequisite(new CompletedPrerequisite("FARM47_2_SQ_070"));
		AddPrerequisite(new LevelPrerequisite(89));

		AddReward(new ItemReward("FARM47_2_SQ_080_ITEM_1", 1));

		AddDialogHook("FARM47_JONARIS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JOANA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_2_SQ_080_ST", "FARM47_2_SQ_080", "Joana may have it", "About the possibility that the magic circle may be for the purification", "It won't be here"))
			{
				case 1:
					await dialog.Msg("FARM47_2_SQ_080_AC");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("FARM47_2_SQ_080_ADD");
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
			await dialog.Msg("FARM47_2_SQ_080_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

