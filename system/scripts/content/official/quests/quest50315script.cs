//--- Melia Script -----------------------------------------------------------
// [Event] Scavenge Challenge
//--- Description -----------------------------------------------------------
// Quest to Check the Event Notice Board.
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

[QuestScript(50315)]
public class Quest50315Script : QuestScript
{
	protected override void Load()
	{
		SetId(50315);
		SetName("[Event] Scavenge Challenge");
		SetDescription("Check the Event Notice Board");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("STEAM_TREASURE_EVENT", "BeforeStart", BeforeStart);
		AddDialogHook("EV_TREASURE_SCC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

