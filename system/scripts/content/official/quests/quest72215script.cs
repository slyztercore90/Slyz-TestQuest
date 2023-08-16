//--- Melia Script -----------------------------------------------------------
// The Final Battle (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72215)]
public class Quest72215Script : QuestScript
{
	protected override void Load()
	{
		SetId(72215);
		SetName("The Final Battle (7)");
		SetDescription("Talk to Resistance Commander Byle");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_92_MQ_60"));
		AddPrerequisite(new LevelPrerequisite(386));

		AddReward(new ExpReward(137754832, 137754832));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 104));

		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_92_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("STARTOWER_92_MQ_70_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

