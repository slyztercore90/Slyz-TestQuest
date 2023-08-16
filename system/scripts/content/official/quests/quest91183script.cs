//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002458
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002494.
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

[QuestScript(91183)]
public class Quest91183Script : QuestScript
{
	protected override void Load()
	{
		SetId(91183);
		SetName("QUEST_LV_0500_20230130_002458");
		SetDescription("QUEST_LV_0500_20230130_002494");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY_3_2_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_1"));
		AddPrerequisite(new LevelPrerequisite(487));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_F_ABBEY3_AD1", "BeforeStart", BeforeStart);
		AddDialogHook("AD3_FOLLOWNPC_CHAT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY_3_2_DLG1", "EP15_1_F_ABBEY_3_2", "I will help", "QUEST_LV_0500_20230130_002459"))
			{
				case 1:
					// Func/SCR_FOLLOWNPC_AD3_SUMMON;
					dialog.HideNPC("EP15_1_F_ABBEY3_AD1");
					await dialog.Msg("EP15_1_F_ABBEY_3_2_DLG2");
					dialog.UnHideNPC("EP15_1_FABBEY3_BLOCK");
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
			await dialog.Msg("EP15_1_F_ABBEY_3_2_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY_3_3");
	}
}

