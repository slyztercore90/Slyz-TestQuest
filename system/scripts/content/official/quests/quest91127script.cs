//--- Melia Script -----------------------------------------------------------
// Cross the Threshold
//--- Description -----------------------------------------------------------
// Quest to Complete [Goddess: Delmore Battlefield].
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

[QuestScript(91127)]
public class Quest91127Script : QuestScript
{
	protected override void Load()
	{
		SetId(91127);
		SetName("Cross the Threshold");
		SetDescription("Complete [Goddess: Delmore Battlefield]");

		AddPrerequisite(new CompletedPrerequisite("EP14_F_CASTLE_5_RAID_1"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP14_F_CASTLE_5_RAID_2_CNPC_DLG1");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			dialog.HideNPC("EP14_1_FCASTLE5_MQ_8_NPC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

