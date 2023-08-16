//--- Melia Script -----------------------------------------------------------
// The Dream Bow Book (3)
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

[QuestScript(72134)]
public class Quest72134Script : QuestScript
{
	protected override void Load()
	{
		SetId(72134);
		SetName("The Dream Bow Book (3)");
		SetDescription("Give the book to the Hunter Master.");
		SetTrack("SProgress", "ESuccess", "JOB_HUNTER2_3_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("MASTER_HUNTER1_2"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddReward(new ItemReward("MASTER_HUNTER1_3_ITEM", 1));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HUNTER2_3_select1", "MASTER_HUNTER1_3", "I'll go to the Archer Master", "Decline"))
			{
				case 1:
					// Func/SCR_MASTER_HUNTER1_3_START;
					await dialog.Msg("MASTER_HUNTER1_3_DLG1");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("JOB_HUNTER2_3_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

