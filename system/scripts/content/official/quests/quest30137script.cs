//--- Melia Script -----------------------------------------------------------
// Sabotaging the Research (1)
//--- Description -----------------------------------------------------------
// Quest to Return to Gatre.
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

[QuestScript(30137)]
public class Quest30137Script : QuestScript
{
	protected override void Load()
	{
		SetId(30137);
		SetName("Sabotaging the Research (1)");
		SetDescription("Return to Gatre");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(220));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_34_1_SQ_8_select", "ORCHARD_34_1_SQ_8", "Let's check the research paper", "There's nothing suspicious"))
			{
				case 1:
					await dialog.Msg("ORCHARD_34_1_SQ_8_agree");
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
			await dialog.Msg("ORCHARD_34_1_SQ_8_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

