//--- Melia Script -----------------------------------------------------------
// Fedimian Completionist [Archer Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Report to the Archer Master.
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

[QuestScript(1123)]
public class Quest1123Script : QuestScript
{
	protected override void Load()
	{
		SetId(1123);
		SetName("Fedimian Completionist [Archer Advancement] (3)");
		SetDescription("Report to the Archer Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_ARCHER3_2"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("JOB_ARCHER3_3_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

