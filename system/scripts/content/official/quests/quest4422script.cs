//--- Melia Script -----------------------------------------------------------
// Missing Researcher (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Airine.
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

[QuestScript(4422)]
public class Quest4422Script : QuestScript
{
	protected override void Load()
	{
		SetId(4422);
		SetName("Missing Researcher (5)");
		SetDescription("Talk to Assistant Airine");
		SetTrack("SProgress", "ESuccess", "ROKAS27_QB_10_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_8"));
		AddPrerequisite(new LevelPrerequisite(67));

		AddObjective("kill0", "Kill 1 Scorpio", new KillObjective(41379, 1));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("misc_Confinedion", 1));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_AIRINE", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_AIRINE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS27_QB_10_select1", "ROKAS27_QB_10", "Say goodbye", "Tell her that it would be better to take some rest here"))
			{
				case 1:
					dialog.HideNPC("ROKAS27_DESIG_02");
					dialog.UnHideNPC("ROKAS27_DESIG_03");
					await dialog.Msg("EffectLocalNPC/ROKAS27_AIRINE/F_pc_warp_circle/1/BOT");
					await dialog.Msg("FadeOutIN/1000");
					dialog.HideNPC("ROKAS27_AIRINE");
					dialog.UnHideNPC("ROKAS27_AIRINE2");
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
			await dialog.Msg("ROKAS27_QB_10_succ1");
			dialog.HideNPC("ROKAS27_AIRINE_EFFECT");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS27_QB_11");
	}
}

