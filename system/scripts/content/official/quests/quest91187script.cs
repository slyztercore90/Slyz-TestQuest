//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002464
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002572.
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

[QuestScript(91187)]
public class Quest91187Script : QuestScript
{
	protected override void Load()
	{
		SetId(91187);
		SetName("QUEST_LV_0500_20230130_002464");
		SetDescription("QUEST_LV_0500_20230130_002572");
		SetTrack("SPossible", "ESuccess", "EP15_1_F_ABBEY_3_6_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_5"));
		AddPrerequisite(new LevelPrerequisite(487));
		AddPrerequisite(new ItemPrerequisite("EP15_1_F_ABBEY2_MQ_6_ITEM1", 1));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_F_ABBEY3_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP15_1_F_ABBEY3_6_DLG11");
			await dialog.Msg("FadeOutIN/1500");
			dialog.HideNPC("EP15_1_F_ABBEY3_AD2");
			// Func/SCR_EP15_1_END_balloon;
			dialog.UnHideNPC("EP15_1_F_ABBEY_3_SQ1_BOOK1");
			dialog.UnHideNPC("EP15_1_F_ABBEY_3_SQ1_BOOK2");
			dialog.UnHideNPC("EP15_1_F_ABBEY_3_SQ2_BOOK1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("EP15_1_F_ABBEY3_AD2");
		dialog.UnHideNPC("GODDESS_RAID_ROZE_PORTAL");
	}
}

