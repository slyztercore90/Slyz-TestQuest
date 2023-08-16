//--- Melia Script -----------------------------------------------------------
// The Great Problem-Solver (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Baron Munchausen.
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

[QuestScript(90187)]
public class Quest90187Script : QuestScript
{
	protected override void Load()
	{
		SetId(90187);
		SetName("The Great Problem-Solver (5)");
		SetDescription("Talk to Baron Munchausen");
		SetTrack("SProgress", "ESuccess", "LOWLV_BOASTER_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_BOASTER_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(290));

		AddObjective("kill0", "Kill 8 Catacombs Leaf Bug(s)", new KillObjective(107024, 8));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 2));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeStart", BeforeStart);
		AddDialogHook("LOWLV_BOASTER_MUENCHHAUSEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LOWLV_BOASTER_SQ_50_ST", "LOWLV_BOASTER_SQ_50", "What should I do?", "I am not your student!"))
			{
				case 1:
					await dialog.Msg("LOWLV_BOASTER_SQ_50_AG");
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
			await dialog.Msg("LOWLV_BOASTER_SQ_50_SU");
			dialog.HideNPC("LOWLV_BOASTER_MUENCHHAUSEN");
			await dialog.Msg("FadeOutIN/2000");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

