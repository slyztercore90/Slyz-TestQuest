//--- Melia Script -----------------------------------------------------------
// Shield Over Flowers (2)
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

[QuestScript(72137)]
public class Quest72137Script : QuestScript
{
	protected override void Load()
	{
		SetId(72137);
		SetName("Shield Over Flowers (2)");
		SetDescription("Report to the Highlander Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("MASTER_HIGHLANDER1_1"));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
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

		await dialog.Msg("JOB_HIGHLANDER2_2_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

