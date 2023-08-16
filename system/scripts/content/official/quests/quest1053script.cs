//--- Melia Script -----------------------------------------------------------
// Stonemason Pipoti's Friend
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Pipoti.
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

[QuestScript(1053)]
public class Quest1053Script : QuestScript
{
	protected override void Load()
	{
		SetId(1053);
		SetName("Stonemason Pipoti's Friend");
		SetDescription("Talk to Stonemason Pipoti");
		SetTrack("SProgress", "ESuccess", "ROKAS30_PIPOTI01_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(76));

		AddObjective("kill0", "Kill 10 Hogma Scout(s)", new KillObjective(47309, 10));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("ROKAS30_PIPOTI_MAP", 1));
		AddReward(new ItemReward("Vis", 1444));

		AddDialogHook("ROKAS30_PIPOTI", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS30_PIPOTI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS30_PIPOTI01_select1", "ROKAS30_PIPOTI01", "I will find your colleague", "I will come back soon"))
			{
				case 1:
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
			await dialog.Msg("ROKAS30_PIPOTI01_succ1");
			await dialog.Msg("EffectLocalNPC/ROKAS30_PIPOTI/F_pc_warp_circle/1/BOT");
			await dialog.Msg("FadeOutIN/300");
			dialog.HideNPC("ROKAS30_PIPOTI");
			dialog.UnHideNPC("ROKAS24_PIPOTI");
			await Task.Delay(2000);
			dialog.AddonMessage("NOTICE_Dm_Clear", "Find the location of the treasure by right-clicking on the treasure map!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

