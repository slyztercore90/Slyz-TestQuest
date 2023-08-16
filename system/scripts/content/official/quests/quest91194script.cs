//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002481
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002607.
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

[QuestScript(91194)]
public class Quest91194Script : QuestScript
{
	protected override void Load()
	{
		SetId(91194);
		SetName("QUEST_LV_0500_20230130_002481");
		SetDescription("QUEST_LV_0500_20230130_002607");

		AddPrerequisite(new LevelPrerequisite(485));

		AddObjective("kill0", "Kill 20 Vubbe Rider(s) or Vubbe Warrior(s) or Vubbe Shaman(s)", new KillObjective(20, 59777, 59780, 59778));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 200000));

		AddDialogHook("EP15_1_ABBEY2_SQ3_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_F_ABBEY2_1_TRIGGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_ABBEY2_SQ3_DLG1", "EP15_1_ABBEY2_SQ3", "I will help", "Do as you wish"))
			{
				case 1:
					await dialog.Msg("EP15_1_ABBEY2_SQ3_DLG2");
					dialog.HideNPC("EP15_1_ABBEY2_SQ3_NPC");
					// Func/SCR_FOLLOWNPC_SQ3_NPC_SUMMON;
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
			// Func/FOLLOWNPC_SQ3_NPC_CANCEL;
			// Func/SCR_EP15_1_ABBEY2_SQ3_TRACK;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

