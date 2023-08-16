//--- Melia Script -----------------------------------------------------------
// Those Named Nijole (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Orsha Port Entry Officer.
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

[QuestScript(91129)]
public class Quest91129Script : QuestScript
{
	protected override void Load()
	{
		SetId(91129);
		SetName("Those Named Nijole (1)");
		SetDescription("Find the Orsha Port Entry Officer");

		AddPrerequisite(new CompletedPrerequisite("EP14_F_CORAL_RAID_1"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddDialogHook("EP14_F_CORAL_RAID_1_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_NIJOLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_F_CORAL_RAID_2_SNPC_DLG1", "EP14_F_CORAL_RAID_2", "I'll go there", "I'm busy with other things"))
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
			await dialog.Msg("EP14_F_CORAL_RAID_2_CNPC_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

