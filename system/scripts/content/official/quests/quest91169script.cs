//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002430
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002502.
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

[QuestScript(91169)]
public class Quest91169Script : QuestScript
{
	protected override void Load()
	{
		SetId(91169);
		SetName("QUEST_LV_0500_20230130_002430");
		SetDescription("QUEST_LV_0500_20230130_002502");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY1_5_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_4"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_AD3", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY1_AD2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_5_DLG1", "EP15_1_F_ABBEY1_5", "Alright", "That's not something I want to do."))
			{
				case 1:
					await dialog.Msg("EP15_1_F_ABBEY1_5_DLG2");
					await dialog.Msg("FadeOutIN/2000");
					dialog.HideNPC("EP15_1_FABBEY1_ROZE3");
					dialog.HideNPC("EP15_1_FABBEY1_AD3");
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

		return HookResult.Continue;
	}
}

