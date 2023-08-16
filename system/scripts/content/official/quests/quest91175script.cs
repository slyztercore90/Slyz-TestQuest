//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002442
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

[QuestScript(91175)]
public class Quest91175Script : QuestScript
{
	protected override void Load()
	{
		SetId(91175);
		SetName("QUEST_LV_0500_20230130_002442");
		SetDescription("QUEST_LV_0500_20230130_002520");
		SetTrack("SPossible", "ESuccess", "EP15_1_F_ABBEY2_2_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_1"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			if (character.Inventory.HasItem("EP15_1_F_ABBEY2_MQ_2_ITEM1", 6))
			{
				character.Inventory.RemoveItem("EP15_1_F_ABBEY2_MQ_2_ITEM1", 6);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EP15_1_F_ABBEY2_2_DLG2");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_3");
	}
}

