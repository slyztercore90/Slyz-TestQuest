//--- Melia Script -----------------------------------------------------------
// Guilty Conscience [Sapper Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Master.
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

[QuestScript(1082)]
public class Quest1082Script : QuestScript
{
	protected override void Load()
	{
		SetId(1082);
		SetName("Guilty Conscience [Sapper Advancement] (4)");
		SetDescription("Talk to the Sapper Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_SAPPER2_3"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SAPPER2_1_NPC", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("JOB_SAPPER2_4_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

