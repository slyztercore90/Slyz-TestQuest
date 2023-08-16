//--- Melia Script -----------------------------------------------------------
// Troublemaker Ridimeds (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Ruthalen.
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

[QuestScript(90051)]
public class Quest90051Script : QuestScript
{
	protected override void Load()
	{
		SetId(90051);
		SetName("Troublemaker Ridimeds (2)");
		SetDescription("Talk to Dievdirbys Ruthalen");
		SetTrack("SPossible", "ESuccess", "KATYN_45_2_SQ_10_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_2_SQ_9"));
		AddPrerequisite(new LevelPrerequisite(249));

		AddObjective("kill0", "Kill 22 Blue Ridimed(s)", new KillObjective(400542, 22));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 9213));

		AddDialogHook("KATYN_45_2_SCULPTOR2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_2_SCULPTOR2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_45_2_SQ_10_ST", "KATYN_45_2_SQ_10", "Alright", "Give me some time to prepare"))
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
			await dialog.Msg("KATYN_45_2_SQ_10_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

