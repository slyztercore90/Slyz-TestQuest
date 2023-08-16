//--- Melia Script -----------------------------------------------------------
// Great Success or Great Failure (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80072)]
public class Quest80072Script : QuestScript
{
	protected override void Load()
	{
		SetId(80072);
		SetName("Great Success or Great Failure (1)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_SQ_8_NPC_END", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_35_1_SQ_8_start", "SIAULIAI_35_1_SQ_8", "Let's go together", "Do it alone"))
			{
				case 1:
					dialog.HideNPC("SIAULIAI_35_1_LUCIEN_2");
					// Func/SIAULIAI_35_1_SQ_8_NPC;
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
			await dialog.Msg("SIAULIAI_35_1_SQ_8_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

