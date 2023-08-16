//--- Melia Script -----------------------------------------------------------
// Retreat (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Assistant Commander Vilas.
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

[QuestScript(50189)]
public class Quest50189Script : QuestScript
{
	protected override void Load()
	{
		SetId(50189);
		SetName("Retreat (6)");
		SetDescription("Talk to Assistant Commander Vilas");
		SetTrack("SProgress", "ESuccess", "TABLELAND_74_SQ6_TRACK", "boss_a");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_74_SQ5"));
		AddPrerequisite(new LevelPrerequisite(253));

		AddObjective("kill0", "Kill 1 Dullahan", new KillObjective(103041, 1));

		AddReward(new ExpReward(8865549, 8865549));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 70840));

		AddDialogHook("TABLE74_SUBQ_SOLDIER2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE74_SUBQ_SOLDIER2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_74_SQ6_startnpc1", "TABLELAND_74_SQ6", "Let's hurry and leave this place.", "We should wait a little longer."))
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
			await dialog.Msg("TABLELAND_74_SQ6_succ1");
			dialog.HideNPC("TABLE74_SUBQ_SOLDIER2_2");
			// Func/TABLE74_SUBQ6_COMPLETE;
			await dialog.Msg("FadeOutIN/1000");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

