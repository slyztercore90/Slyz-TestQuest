//--- Melia Script -----------------------------------------------------------
// The stack of food at Starving Demon's Way (2)
//--- Description -----------------------------------------------------------
// Quest to Look closely at the piled up food.
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

[QuestScript(19541)]
public class Quest19541Script : QuestScript
{
	protected override void Load()
	{
		SetId(19541);
		SetName("The stack of food at Starving Demon's Way (2)");
		SetDescription("Look closely at the piled up food");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_110"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("PILGRIM46_FOOD03_1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

