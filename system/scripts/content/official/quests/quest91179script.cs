//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002450
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002545.
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

[QuestScript(91179)]
public class Quest91179Script : QuestScript
{
	protected override void Load()
	{
		SetId(91179);
		SetName("QUEST_LV_0500_20230130_002450");
		SetDescription("QUEST_LV_0500_20230130_002545");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY2_5"));
		AddPrerequisite(new LevelPrerequisite(485));

		AddReward(new ExpReward(1800000000, 1800000000));
		AddReward(new ItemReward("Vis", 41379));

		AddDialogHook("ORSHA_COLLECTION_SHOP", "BeforeStart", BeforeStart);
		AddDialogHook("EP15_1_FABBEY2_ROZE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP15_1_F_ABBEY2_6_DLG1", "EP15_1_F_ABBEY2_6", "QUEST_LV_0500_20230130_002451", "QUEST_LV_0500_20230130_002452"))
			{
				case 1:
					await dialog.Msg("EP15_1_F_ABBEY2_6_DLG2");
					dialog.UnHideNPC("EP15_F_ABBEY2_6_NPC");
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
			await dialog.Msg("EP15_1_F_ABBEY2_6_DLG4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP15_1_F_ABBEY2_7");
	}
}

