//--- Melia Script -----------------------------------------------------------
// Sabotaging the Research (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Gatre.
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

[QuestScript(30139)]
public class Quest30139Script : QuestScript
{
	protected override void Load()
	{
		SetId(30139);
		SetName("Sabotaging the Research (3)");
		SetDescription("Talk with Gatre");

		AddPrerequisite(new LevelPrerequisite(220));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_34_1_SQ_9"));

		AddDialogHook("ORCHARD_34_1_SQ_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD_34_1_SQ_NPC_2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_34_1_SQ_10_select", "ORCHARD_34_1_SQ_10", "I'll take it", "Let's quit since we may get discovered"))
		{
			case 1:
				await dialog.Msg("ORCHARD_34_1_SQ_10_agree");
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

		await dialog.Msg("ORCHARD_34_1_SQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

