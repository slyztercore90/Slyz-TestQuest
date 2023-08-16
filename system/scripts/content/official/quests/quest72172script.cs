//--- Melia Script -----------------------------------------------------------
// Legend of the Winter Season (2)
//--- Description -----------------------------------------------------------
// Quest to Ask the Miners' Village Mayor about the whereabouts of the book.
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

[QuestScript(72172)]
public class Quest72172Script : QuestScript
{
	protected override void Load()
	{
		SetId(72172);
		SetName("Legend of the Winter Season (2)");
		SetDescription("Ask the Miners' Village Mayor about the whereabouts of the book");
		SetTrack("SProgress", "ESuccess", "MASTER_CRYOMANCER2_2_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("MASTER_CRYOMANCER2_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_CRYOMANCER2_2_DLG2", "MASTER_CRYOMANCER2_2", "I'll try to find them", "I'll wish for it next time"))
			{
				case 1:
					await dialog.Msg("JOB_CRYOMANCER2_2_prog1");
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
			await dialog.Msg("EffectLocalNPC/MASTER_ICEMAGE/archer_buff_skl_Recuperate_circle/1.5/BOT");
			await dialog.Msg("MASTER_CRYOMANCER2_2_DLG1");
			await dialog.Msg("FadeOutIN/1000");
			await dialog.Msg("MASTER_CRYOMANCER2_2_DLG3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

