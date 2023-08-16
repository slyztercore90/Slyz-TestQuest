//--- Melia Script -----------------------------------------------------------
// Pledge of Duty (2)
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

[QuestScript(72139)]
public class Quest72139Script : QuestScript
{
	protected override void Load()
	{
		SetId(72139);
		SetName("Pledge of Duty (2)");
		SetDescription("Report to the Peltasta Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_PELTASTA1_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

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
			await dialog.Msg("MASTER_PELTASTA1_2_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

