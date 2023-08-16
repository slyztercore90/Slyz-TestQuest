//--- Melia Script -----------------------------------------------------------
// Secret of the Destroyed Altar
//--- Description -----------------------------------------------------------
// Quest to Northern Rudiziu Trail Altar.
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

[QuestScript(19700)]
public class Quest19700Script : QuestScript
{
	protected override void Load()
	{
		SetId(19700);
		SetName("Secret of the Destroyed Altar");
		SetDescription("Northern Rudiziu Trail Altar");
		SetTrack("SProgress", "ESuccess", "PILGRIM50_SQ_090_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("kill0", "Kill 1 Merge", new KillObjective(57298, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("PILGRIM50_SQ_090_ITEM", 1));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ALTAR01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM50_GHOST4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("PILGRIM50_SQ_090_COMP");
			await dialog.Msg("EffectLocalNPC/PILGRIM50_GHOST4/I_smoke013_dark/1/BOT");
			await dialog.Msg("FadeOutIN/1000");
			dialog.HideNPC("PILGRIM50_GHOST4");
			dialog.AddonMessage("NOTICE_Dm_Exclaimation", "The Pilgrim's Soul disappeared!", 3);
			await Task.Delay(4000);
			// Func/SCR_PILGRIM50_PC_ASIDE;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

