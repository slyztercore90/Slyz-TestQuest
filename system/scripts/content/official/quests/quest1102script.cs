//--- Melia Script -----------------------------------------------------------
// Shield over Flowers [Highlander Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Report to the Highlander Master.
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

[QuestScript(1102)]
public class Quest1102Script : QuestScript
{
	protected override void Load()
	{
		SetId(1102);
		SetName("Shield over Flowers [Highlander Advancement] (2)");
		SetDescription("Report to the Highlander Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_HIGHLANDER2_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_HIGHLANDER2_2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

