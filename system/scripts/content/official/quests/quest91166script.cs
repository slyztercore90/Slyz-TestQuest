//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002420
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002490.
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

[QuestScript(91166)]
public class Quest91166Script : QuestScript
{
	protected override void Load()
	{
		SetId(91166);
		SetName("QUEST_LV_0500_20230130_002420");
		SetDescription("QUEST_LV_0500_20230130_002490");
		SetTrack("SSuccess", "ESuccess", "EP15_1_F_ABBEY1_2_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY1_1"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddDialogHook("NPC_LITTLEGIRL_01", "BeforeStart", BeforeStart);
		AddDialogHook("WARP_C_KLAIPE_CATHEDRAL_MEDIUM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY1_2_DLG1", "EP15_1_F_ABBEY1_2", "QUEST_LV_0500_20230130_002421", "QUEST_LV_0500_20230130_002422"))
			{
				case 1:
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
			dialog.UnHideNPC("EP15_1_FABBEY1_AD1");
			dialog.UnHideNPC("EP15_1_FABBEY1_ROZE1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

