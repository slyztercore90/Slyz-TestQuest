//--- Melia Script -----------------------------------------------------------
// [Weekly] Conquest - Assister Dungeon
//--- Description -----------------------------------------------------------
// Quest to Clear Assister Dungeon Section 6 or above.
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

[QuestScript(510009)]
public class Quest510009Script : QuestScript
{
	protected override void Load()
	{
		SetId(510009);
		SetName("[Weekly] Conquest - Assister Dungeon");
		SetDescription("Clear Assister Dungeon Section 6 or above");

		AddPrerequisite(new LevelPrerequisite(458));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

