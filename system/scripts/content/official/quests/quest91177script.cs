//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002446
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002520.
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

[QuestScript(91177)]
public class Quest91177Script : QuestScript
{
	protected override void Load()
	{
		SetId(91177);
		SetName("QUEST_LV_0500_20230130_002446");
		SetDescription("QUEST_LV_0500_20230130_002520");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY2_4_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_3"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY2_4_DLG1", "EP15_1_F_ABBEY2_4", "Alright", "QUEST_LV_0500_20230130_002447"))
			{
				case 1:
					// Func/SCR_EP15_1_ABBEY2_SUMMON_ABANDON;
					dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER01");
					dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER02");
					dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER03");
					dialog.UnHideNPC("EP15_1_FABBEY2_MQ4_BOWER04");
					dialog.HideNPC("EP15_1_FABBEY2_AD1");
					dialog.HideNPC("EP15_1_FABBEY2_ROZE1");
					await dialog.Msg("EP15_1_F_ABBEY2_4_DLG2");
					dialog.UnHideNPC("EP15_1_GLOVECUPSULE");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("EP15_1_F_ABBEY2_4_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_5");
	}
}

