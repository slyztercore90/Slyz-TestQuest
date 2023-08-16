//--- Melia Script -----------------------------------------------------------
// Monster Gone Wild (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(50010)]
public class Quest50010Script : QuestScript
{
	protected override void Load()
	{
		SetId(50010);
		SetName("Monster Gone Wild (2)");
		SetDescription("Talk to the Pyromancer Master");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_50_1_SQ_030_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_020"));
		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("kill0", "Kill 1 Austeja Altar", new KillObjective(151024, 1));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_50_1_SQ_030_select01", "SIAULIAI_50_1_SQ_030", "I will investigate the settlement area", "Reject since it looks dangerous"))
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
			await dialog.Msg("SIAULIAI_50_1_SQ_030_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_50_1_SQ_040");
	}
}

