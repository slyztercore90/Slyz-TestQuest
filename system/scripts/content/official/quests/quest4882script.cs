//--- Melia Script -----------------------------------------------------------
// Bonfire of the Patrol Route (4)
//--- Description -----------------------------------------------------------
// Quest to Light up the Bonfires.
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

[QuestScript(4882)]
public class Quest4882Script : QuestScript
{
	protected override void Load()
	{
		SetId(4882);
		SetName("Bonfire of the Patrol Route (4)");
		SetDescription("Light up the Bonfires");

		AddPrerequisite(new CompletedPrerequisite("SUCH_POINT_01"));
		AddPrerequisite(new LevelPrerequisite(106));

		AddDialogHook("KATYN_SUCH_POINT_04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

