//--- Melia Script -----------------------------------------------------------
// Support for the Greater Justice (4)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80071)]
public class Quest80071Script : QuestScript
{
	protected override void Load()
	{
		SetId(80071);
		SetName("Support for the Greater Justice (4)");
		SetDescription("Talk with Lucienne Winterspoon");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_35_1_SQ_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8028));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_35_1_SQ_7_start", "SIAULIAI_35_1_SQ_7", "Leave it to me", "I'm not so sure about it"))
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
			await dialog.Msg("SIAULIAI_35_1_SQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

