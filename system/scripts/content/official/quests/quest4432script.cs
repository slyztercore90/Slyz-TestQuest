//--- Melia Script -----------------------------------------------------------
// Crazy Archivist (2)
//--- Description -----------------------------------------------------------
// Quest to Find Archivist Jonas.
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

[QuestScript(4432)]
public class Quest4432Script : QuestScript
{
	protected override void Load()
	{
		SetId(4432);
		SetName("Crazy Archivist (2)");
		SetDescription("Find Archivist Jonas");
		SetTrack("SProgress", "ESuccess", "ROKAS24_QB_5_NEW_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS24_DIALOG1"));
		AddPrerequisite(new LevelPrerequisite(58));

		AddReward(new ExpReward(42210, 42210));
		AddReward(new ItemReward("expCard3", 1));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_FLORIJONAS", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_FLORIJONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS24_QB_5_select1", "ROKAS24_QB_5", "Persuade him to go back since this place is too dangerous", "Alright"))
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
			await dialog.Msg("ROKAS24_QB_5_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

