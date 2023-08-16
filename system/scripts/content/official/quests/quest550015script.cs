//--- Melia Script -----------------------------------------------------------
// QUEST_LV_0500_20230703_002652
//--- Description -----------------------------------------------------------
// Quest to QUEST_LV_0500_20230703_002654.
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

[QuestScript(550015)]
public class Quest550015Script : QuestScript
{
	protected override void Load()
	{
		SetId(550015);
		SetName("QUEST_LV_0500_20230703_002652");
		SetDescription("QUEST_LV_0500_20230703_002654");

		AddPrerequisite(new LevelPrerequisite(490));

		AddDialogHook("MASTER_ENG_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ENG_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UQ_Char3_23_PRE1_DLG1", "UQ_Char3_23_PRE1", "Interested.", "QUEST_LV_0500_20230703_002653"))
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
			await dialog.Msg("UQ_Char3_23_PRE1_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

