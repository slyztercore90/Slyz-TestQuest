//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002485
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002618.
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

[QuestScript(91196)]
public class Quest91196Script : QuestScript
{
	protected override void Load()
	{
		SetId(91196);
		SetName("QUEST_LV_0500_20230130_002485");
		SetDescription("QUEST_LV_0500_20230130_002618");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_SQ1"));
		AddPrerequisite(new LevelPrerequisite(489));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("C_ORSHA_SOLDIER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP15_1_ABBEY3_SQ2_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

