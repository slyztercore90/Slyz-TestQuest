//--- Melia Script -----------------------------------------------------------
// The Story Behind Them (1)
//--- Description -----------------------------------------------------------
// Quest to Check the memo of the commander.
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

[QuestScript(80062)]
public class Quest80062Script : QuestScript
{
	protected override void Load()
	{
		SetId(80062);
		SetName("The Story Behind Them (1)");
		SetDescription("Check the memo of the commander");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_09"));
		AddPrerequisite(new LevelPrerequisite(208));

		AddDialogHook("TABLELAND_11_1_SQ_03_LOCK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("TABLELAND_11_1_SQ_11_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

