//--- Melia Script -----------------------------------------------------------
// [Event] Scavenge Challenge
//--- Description -----------------------------------------------------------
// Quest to Talk to the Treasure Chest Helper.
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

[QuestScript(50303)]
public class Quest50303Script : QuestScript
{
	protected override void Load()
	{
		SetId(50303);
		SetName("[Event] Scavenge Challenge");
		SetDescription("Talk to the Treasure Chest Helper");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("EV_TREASURE_QUEST", "BeforeStart", BeforeStart);
		AddDialogHook("EV_TREASURE_SCC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


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

