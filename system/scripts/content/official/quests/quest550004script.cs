//--- Melia Script -----------------------------------------------------------
// [Hwarang] Bouquet of the Goddess
//--- Description -----------------------------------------------------------
// Quest to Go to the Hwarang Master at Orsha.
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

[QuestScript(550004)]
public class Quest550004Script : QuestScript
{
	protected override void Load()
	{
		SetId(550004);
		SetName("[Hwarang] Bouquet of the Goddess");
		SetDescription("Go to the Hwarang Master at Orsha");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_HWARANG_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HWARANG_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UQ_Char3_22_PRE1_DLG1", "UQ_Char3_22_PRE1", "I will follow the path of the Hwarang.", "I'm sorry, but I don't think I can"))
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
			await dialog.Msg("UQ_Char3_22_PRE1_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

