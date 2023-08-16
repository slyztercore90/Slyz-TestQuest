//--- Melia Script -----------------------------------------------------------
// A Mediator is Born (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aeglei.
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

[QuestScript(90102)]
public class Quest90102Script : QuestScript
{
	protected override void Load()
	{
		SetId(90102);
		SetName("A Mediator is Born (2)");
		SetDescription("Talk to Kupole Aeglei");

		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_70"));
		AddPrerequisite(new LevelPrerequisite(289));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12138));

		AddDialogHook("MAPLE_25_3_EGLE", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_3_EGLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE_25_3_SQ_80_ST", "MAPLE_25_3_SQ_80", "I'll go there", "I'll go a bit later."))
			{
				case 1:
					await dialog.Msg("MAPLE_25_3_SQ_80_AG");
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
			await dialog.Msg("MAPLE_25_3_SQ_80_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

