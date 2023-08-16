//--- Melia Script -----------------------------------------------------------
// Historian Rexipher's Research (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Historian Rexipher.
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

[QuestScript(20181)]
public class Quest20181Script : QuestScript
{
	protected override void Load()
	{
		SetId(20181);
		SetName("Historian Rexipher's Research (3)");
		SetDescription("Talk to Historian Rexipher");
		SetTrack("SProgress", "ESuccess", "ROKAS29_MQ3_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 25 Hogma Warrior(s) or Hogma Fighter(s) or Zinutekas(s)", new KillObjective(25, 41433, 47308, 401301));

		AddDialogHook("ROKAS29_MQ_REXITHER3", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS29_MQ_REXITHER4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS29_MQ3_select01", "ROKAS29_MQ3", "Go to where the epitaph is", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/ROKAS29_MQ_REXITHER3/F_pc_warp_circle/1/BOT");
					dialog.HideNPC("ROKAS29_MQ_REXITHER3");
					await dialog.Msg("FadeOutIN/2000");
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
			await dialog.Msg("ROKAS29_MQ3_succ01");
			dialog.UnHideNPC("ROKAS29_MQ_REXITHER4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS29_MQ4");
	}
}

