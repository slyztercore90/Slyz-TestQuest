//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002470
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002582.
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

[QuestScript(91190)]
public class Quest91190Script : QuestScript
{
	protected override void Load()
	{
		SetId(91190);
		SetName("QUEST_LV_0500_20230130_002470");
		SetDescription("QUEST_LV_0500_20230130_002582");

		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("kill0", "Kill 100 Vubbe Chaser(s) or Vubbe Rider(s)", new KillObjective(100, 59779, 59777));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY1_SQ1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_SOLDIER_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_ABBEY1_SQ1_DLG1", "EP15_1_ABBEY1_SQ1", "QUEST_LV_0500_20230130_002471", "QUEST_LV_0500_20230130_002472"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP15_1_ABBEY1_SQ1_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

