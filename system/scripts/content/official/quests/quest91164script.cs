//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20221125_002198
//--- Description -----------------------------------------------------------
// Quest to Talk to Orsha Investigator.
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

[QuestScript(91164)]
public class Quest91164Script : QuestScript
{
	protected override void Load()
	{
		SetId(91164);
		SetName("QUEST_LV_0500_20221125_002198");
		SetDescription("Talk to Orsha Investigator");

		AddPrerequisite(new CompletedPrerequisite("RAID_CASTLE_EP14_2_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(480));

		AddDialogHook("RAID_CASTLE_EP14_2_FSOLD", "BeforeStart", BeforeStart);
		AddDialogHook("RAID_CASTLE_EP14_2_FSOLD", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("RAID_CASTLE_EP14_2_MQ_3_DLG1", "RAID_CASTLE_EP14_2_MQ_3", "Alright", "I will come after doing something else."))
			{
				case 1:
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
			await dialog.Msg("RAID_CASTLE_EP14_2_MQ_3_DLG3");
			await dialog.Msg("FadeOutIN/2500");
			dialog.HideNPC("RAID_CASTLE_EP14_2_FSOLD");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

