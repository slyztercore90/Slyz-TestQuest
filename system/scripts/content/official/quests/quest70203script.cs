//--- Melia Script -----------------------------------------------------------
// Mesafasla, the Strategic Spot (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Mesafasla Assistant Commander Gorman.
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

[QuestScript(70203)]
public class Quest70203Script : QuestScript
{
	protected override void Load()
	{
		SetId(70203);
		SetName("Mesafasla, the Strategic Spot (2)");
		SetDescription("Talk with Mesafasla Assistant Commander Gorman");
		SetTrack("SProgress", "ESuccess", "TABLELAND28_1_SQ04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND28_1_SQ03"));
		AddPrerequisite(new LevelPrerequisite(212));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 5));
		AddReward(new ItemReward("Vis", 7420));

		AddDialogHook("TABLELAND281_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND281_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND28_1_SQ_04_1", "TABLELAND28_1_SQ04", "I can do it", "Decline it since it doesn't look that simple"))
			{
				case 1:
					// Func/SCR_TABLELAND281_SQ_04_TARGET;
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
			await dialog.Msg("TABLELAND28_1_SQ_04_7");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

