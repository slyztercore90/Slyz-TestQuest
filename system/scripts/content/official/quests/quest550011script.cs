//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0100_20221125_017908
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0100_20221125_017911.
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

[QuestScript(550011)]
public class Quest550011Script : QuestScript
{
	protected override void Load()
	{
		SetId(550011);
		SetName("QUEST_LV_0100_20221125_017908");
		SetDescription("QUEST_LV_0100_20221125_017911");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_JAGUAR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_JAGUAR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UQ_Char5_18_PRE1_DLG1", "UQ_Char5_18_PRE1", "QUEST_LV_0100_20221125_017909", "QUEST_LV_0100_20221125_017910"))
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
			await dialog.Msg("UQ_Char5_18_PRE1_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

