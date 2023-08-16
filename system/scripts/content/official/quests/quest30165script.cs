//--- Melia Script -----------------------------------------------------------
// Who am I(2)
//--- Description -----------------------------------------------------------
// Quest to Activate the Secret Device in the Hanging Room.
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

[QuestScript(30165)]
public class Quest30165Script : QuestScript
{
	protected override void Load()
	{
		SetId(30165);
		SetName("Who am I(2)");
		SetDescription("Activate the Secret Device in the Hanging Room");

		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(265));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_OBJ_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_NPC_1", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_PRISON_80_MQ_2_SUCC;
			await dialog.Msg("PRISON_80_MQ_2_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

