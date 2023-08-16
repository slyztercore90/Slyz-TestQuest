//--- Melia Script -----------------------------------------------------------
// Grudge of A Nameless Warrior
//--- Description -----------------------------------------------------------
// Quest to Grudge of A Nameless Warrior.
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

[QuestScript(8274)]
public class Quest8274Script : QuestScript
{
	protected override void Load()
	{
		SetId(8274);
		SetName("Grudge of A Nameless Warrior");
		SetDescription("Grudge of A Nameless Warrior");
		SetTrack("SProgress", "ESuccess", "KATYN14_SUB_08_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(114));

		AddObjective("kill0", "Kill 1 Werewolf", new KillObjective(41247, 1));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("Vis", 2736));

		AddDialogHook("KATYN14_SUB_WOLF", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_SUB_WOLF", "BeforeEnd", BeforeEnd);
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
			await Task.Delay(500);
			await dialog.Msg("EffectLocalNPC/KATYN14_SUB_WOLF/F_pc_warp_circle/1/BOT");
			dialog.HideNPC("KATYN14_SUB_WOLF");
			await dialog.Msg("FadeOutIN/500");
			dialog.HideNPC("KATYN14_SUB_08_STONE");
			dialog.AddonMessage("NOTICE_Dm_Clear", "The keepsakes disappeared with the necklace!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

