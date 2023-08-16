//--- Melia Script -----------------------------------------------------------
// Unsatisfactory Crops (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gareth.
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

[QuestScript(50025)]
public class Quest50025Script : QuestScript
{
	protected override void Load()
	{
		SetId(50025);
		SetName("Unsatisfactory Crops (2)");
		SetDescription("Talk to Gareth");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_50_1_SQ_180_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_170"));
		AddPrerequisite(new LevelPrerequisite(70));

		AddObjective("kill0", "Kill 7 Black Ridimed(s) or Orange Sakmoli(s)", new KillObjective(7, 400543, 400563));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1330));

		AddDialogHook("SIAULIAI_50_1_SQ_RESEARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_50_1_SQ_RESEARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_50_1_SQ_180_select01", "SIAULIAI_50_1_SQ_180", "Ask him how you could help", "Leave here since you've done what you should've done"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_50_1_SQ_180_AG");
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
			await dialog.Msg("SIAULIAI_50_1_SQ_180_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

