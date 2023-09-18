//--- Melia Script -----------------------------------------------------------
// Unbelievable Reality (1)
//--- Description -----------------------------------------------------------
// Quest to Speak with Druid Benes.
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

[QuestScript(80039)]
public class Quest80039Script : QuestScript
{
	protected override void Load()
	{
		SetId(80039);
		SetName("Unbelievable Reality (1)");
		SetDescription("Speak with Druid Benes");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_SQ_02"));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("ORCHARD342_BENES", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD342_BENES", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORCHARD_342_SQ_03_start", "ORCHARD_342_SQ_03", "I'll go now", "I can only help so much"))
		{
			case 1:
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


		return HookResult.Break;
	}
}

