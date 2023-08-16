//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 4 [Ranger Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(1098)]
public class Quest1098Script : QuestScript
{
	protected override void Load()
	{
		SetId(1098);
		SetName("Dream Book of the Bow 4 [Ranger Advancement] (4)");
		SetDescription("Talk to the Ranger Master");
		SetTrack("SProgress", "ESuccess", "JOB_HUNTER2_3_TRACK", 3000);

		AddPrerequisite(new CompletedPrerequisite("JOB_RANGER2_3"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddReward(new ItemReward("Book5", 1));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_RANGER2_4_select1", "JOB_RANGER2_4", "How is it used?", "I'll quit here"))
			{
				case 1:
					await dialog.Msg("JOB_RANGER2_4_agree1");
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
			await dialog.Msg("JOB_RANGER2_4_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

