//--- Melia Script -----------------------------------------------------------
// Truth of the Suspicious Seal Stone (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sealed Stone.
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

[QuestScript(17026)]
public class Quest17026Script : QuestScript
{
	protected override void Load()
	{
		SetId(17026);
		SetName("Truth of the Suspicious Seal Stone (2)");
		SetDescription("Talk to the Sealed Stone");
		SetTrack("SProgress", "ESuccess", "FTOWER45_SQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("FTOWER45_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(126));

		AddObjective("kill0", "Kill 1 Stone Whale", new KillObjective(57091, 1));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_SQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER45_SQ_05_ST", "FTOWER45_SQ_05", "I will release the soul by defeating Stone Whale", "I'm not interested"))
			{
				case 1:
					await dialog.Msg("FTOWER45_SQ_05_AC");
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
			await dialog.Msg("FTOWER45_SQ_05_COMP");
			await dialog.Msg("NPCChat/FTOWER45_SQ_04/이제 정말 풀려 나는군.");
			await dialog.Msg("EffectLocalNPC/FTOWER45_SQ_04/I_pattern002_explosion_mash_green/2/MID");
			dialog.HideNPC("FTOWER45_SQ_04");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

