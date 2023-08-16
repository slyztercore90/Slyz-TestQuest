//--- Melia Script -----------------------------------------------------------
// The stack of food at Starving Demon's Way (4)
//--- Description -----------------------------------------------------------
// Quest to Clean the piled up food.
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

[QuestScript(19543)]
public class Quest19543Script : QuestScript
{
	protected override void Load()
	{
		SetId(19543);
		SetName("The stack of food at Starving Demon's Way (4)");
		SetDescription("Clean the piled up food");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_112"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("PILGRIM46_FOOD03_3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

