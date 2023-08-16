//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002436
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002511.
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

[QuestScript(91172)]
public class Quest91172Script : QuestScript
{
	protected override void Load()
	{
		SetId(91172);
		SetName("QUEST_LV_0500_20230130_002436");
		SetDescription("QUEST_LV_0500_20230130_002511");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY1_8_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_7"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddObjective("kill0", "Kill 1 Vubbas", new KillObjective(59781, 1));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY1_ROZE2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_8_DLG1", "EP15_1_F_ABBEY1_8", "Alright", "QUEST_LV_0500_20230130_002437"))
			{
				case 1:
					// Func/SCR_EP15_1_ABBEY1_SUMMON_ABANDON;
					dialog.HideNPC("EP15_1_FABBEY1_ROZE2");
					dialog.HideNPC("EP15_1_FABBEY1_AD2");
					await dialog.Msg("EP15_1_F_ABBEY1_8_DLG2");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

