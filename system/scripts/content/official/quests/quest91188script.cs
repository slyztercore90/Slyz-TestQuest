//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002465
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002574.
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

[QuestScript(91188)]
public class Quest91188Script : QuestScript
{
	protected override void Load()
	{
		SetId(91188);
		SetName("QUEST_LV_0500_20230130_002465");
		SetDescription("QUEST_LV_0500_20230130_002574");

		AddPrerequisite(new CompletedPrerequisite("EP15_1_F_ABBEY_3_6"));
		AddPrerequisite(new LevelPrerequisite(490));

		AddDialogHook("C_ORSHA_SOLDIER_01", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_EP15_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("RAID_ABBEY_EP15_1_MQ_1_DLG1", "RAID_ABBEY_EP15_1_MQ_1", "Ask what's going on.", "QUEST_LV_0500_20230130_002466"))
			{
				case 1:
					await dialog.Msg("RAID_ABBEY_EP15_1_MQ_1_DLG2");
					dialog.UnHideNPC("Raid_EP15_1_NPC");
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
			await dialog.Msg("RAID_ABBEY_EP15_1_MQ_1_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("RAID_ABBEY_EP15_1_MQ_2");
	}
}

