//--- Melia Script -----------------------------------------------------------
// Remnants of the Past
//--- Description -----------------------------------------------------------
// Quest to Talk to Owynia Dilben.
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

[QuestScript(50382)]
public class Quest50382Script : QuestScript
{
	protected override void Load()
	{
		SetId(50382);
		SetName("Remnants of the Past");
		SetDescription("Talk to Owynia Dilben");
		SetTrack("SProgress", "ESuccess", "F_NICOPOLIS_81_1_SQ_04_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_1_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(381));

		AddObjective("kill0", "Kill 1 Pervading Queen", new KillObjective(59169, 1));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 2));
		AddReward(new ItemReward("Vis", 33316));

		AddDialogHook("NICO811_NPC1_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO811_NPC1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("NICO811_SUBQ4_START1", "F_NICOPOLIS_81_1_SQ_04", "I'll go investigate.", "Leave this place"))
			{
				case 1:
					await dialog.Msg("NICO811_SUBQ4_AGREE1");
					dialog.HideNPC("NICO811_NPC1_2");
					await dialog.Msg("FadeOutIN/1000");
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
			await dialog.Msg("NICO811_SUBQ4_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

