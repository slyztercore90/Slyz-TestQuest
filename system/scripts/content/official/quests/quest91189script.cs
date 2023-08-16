//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230130_002467
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230130_002576.
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

[QuestScript(91189)]
public class Quest91189Script : QuestScript
{
	protected override void Load()
	{
		SetId(91189);
		SetName("QUEST_LV_0500_20230130_002467");
		SetDescription("QUEST_LV_0500_20230130_002576");

		AddPrerequisite(new CompletedPrerequisite("RAID_ABBEY_EP15_1_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(490));

		AddDialogHook("RAID_EP15_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_EP15_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("RAID_ABBEY_EP15_1_MQ_2_DLG1", "RAID_ABBEY_EP15_1_MQ_2", "QUEST_LV_0500_20230130_002468", "QUEST_LV_0500_20230130_002469"))
			{
				case 1:
					await dialog.Msg("RAID_ABBEY_EP15_1_MQ_2_DLG2");
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
			await dialog.Msg("RAID_ABBEY_EP15_1_MQ_2_DLG3");
			dialog.HideNPC("RAID_EP15_1_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

