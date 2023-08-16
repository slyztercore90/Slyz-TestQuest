//--- Melia Script -----------------------------------------------------------
// Duty of the Pledge [Peltasta Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Report to the Peltasta Master.
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

[QuestScript(1104)]
public class Quest1104Script : QuestScript
{
	protected override void Load()
	{
		SetId(1104);
		SetName("Duty of the Pledge [Peltasta Advancement] (2)");
		SetDescription("Report to the Peltasta Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_PELTASTA2_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("JOB_PELTASTA2_2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

