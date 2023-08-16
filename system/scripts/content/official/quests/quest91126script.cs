//--- Melia Script -----------------------------------------------------------
// Delmore Battlefield
//--- Description -----------------------------------------------------------
// Quest to Join the General Ramin.
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

[QuestScript(91126)]
public class Quest91126Script : QuestScript
{
	protected override void Load()
	{
		SetId(91126);
		SetName("Delmore Battlefield");
		SetDescription("Join the General Ramin");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_9"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_F_CASTLE_5_RAID_1_SNPC_DLG1", "EP14_F_CASTLE_5_RAID_1", "I'm ready", "I still need more preparation"))
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
			await dialog.Msg("EP14_F_CASTLE_5_RAID_1_CNPC_DLG1");
			dialog.UnHideNPC("GODDESS_RAID_DELMORE_PORTAL");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_F_CASTLE_5_RAID_2");
	}
}

