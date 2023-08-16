//--- Melia Script -----------------------------------------------------------
// The Dream Bow Book (4)
//--- Description -----------------------------------------------------------
// Quest to Give the book to the Hunter Master..
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

[QuestScript(72135)]
public class Quest72135Script : QuestScript
{
	protected override void Load()
	{
		SetId(72135);
		SetName("The Dream Bow Book (4)");
		SetDescription("Give the book to the Hunter Master.");

		AddPrerequisite(new CompletedPrerequisite("MASTER_HUNTER1_3"));
		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new ItemPrerequisite("MASTER_HUNTER1_3_ITEM", -100));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HUNTER2_4_select1", "MASTER_HUNTER1_4", "I'll deliver the pouch", "Decline"))
			{
				case 1:
					// Func/SCR_MASTER_HUNTER1_4_START;
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
			await dialog.Msg("EffectLocalNPC/MASTER_ARCHER/archer_buff_skl_Recuperate_circle/1.5/BOT");
			await dialog.Msg("MASTER_HUNTER1_4_DLG1");
			await dialog.Msg("FadeOutIN/1000");
			await dialog.Msg("MASTER_HUNTER1_4_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

