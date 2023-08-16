//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230308_002631
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230308_002635.
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

[QuestScript(550013)]
public class Quest550013Script : QuestScript
{
	protected override void Load()
	{
		SetId(550013);
		SetName("QUEST_LV_0500_20230308_002631");
		SetDescription("QUEST_LV_0500_20230308_002635");

		AddPrerequisite(new LevelPrerequisite(490));

		AddDialogHook("MASTER_SPE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SPE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UQ_Char1_24_PRE1_DLG1", "UQ_Char1_24_PRE1", "QUEST_LV_0100_20221125_017909", "QUEST_LV_0500_20230308_002632"))
			{
				case 1:
					// Func/SCR_SET_UNLOCK_AOBJ_UNLOCK;
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
			// Func/SCR_SET_UNLOCK_AOBJ_LOCK;
			await dialog.Msg("UQ_Char1_24_PRE1_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

