//--- Melia Script -----------------------------------------------------------
// A Highlander's Determination [Highlander Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Highlander Submaster.
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

[QuestScript(70319)]
public class Quest70319Script : QuestScript
{
	protected override void Load()
	{
		SetId(70319);
		SetName("A Highlander's Determination [Highlander Advancement]");
		SetDescription("Talk with the Highlander Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_HIGHLANDER_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_HIGHLANDER4_1_1", "JOB_2_HIGHLANDER4", "I request to you earnestly", "You are already strong enough"))
		{
			case 1:
				await dialog.Msg("JOB_2_HIGHLANDER4_1_2");
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

