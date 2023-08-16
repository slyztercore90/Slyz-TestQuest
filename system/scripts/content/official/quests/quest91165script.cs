//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002417
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002486.
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

[QuestScript(91165)]
public class Quest91165Script : QuestScript
{
	protected override void Load()
	{
		SetId(91165);
		SetName("QUEST_LV_0500_20230130_002417");
		SetDescription("QUEST_LV_0500_20230130_002486");
		SetTrack("SProgress", "ESuccess", "EP15_1_F_ABBEY1_1_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE3_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_1_DLG1", "EP15_1_F_ABBEY1_1", "QUEST_LV_0500_20230130_002418", "QUEST_LV_0500_20230130_002419"))
			{
				case 1:
					await dialog.Msg("EP15_1_F_ABBEY1_1_DLG2");
					dialog.AddonMessage("NOTICE_Dm_Scroll", "Worship the Statue of Goddess Ausrine in the Central Plaza!", 8);
					// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

