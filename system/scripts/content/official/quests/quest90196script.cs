//--- Melia Script -----------------------------------------------------------
// Ritual for the Sea(2)
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90196)]
public class Quest90196Script : QuestScript
{
	protected override void Load()
	{
		SetId(90196);
		SetName("Ritual for the Sea(2)");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack("SPossible", "ESuccess", "CORAL_44_1_SQ_90_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_1_SQ_80"));
		AddPrerequisite(new LevelPrerequisite(327));

		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_1_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_1_SQ_90_ST", "CORAL_44_1_SQ_90", "Tell him that it won't be a problem", "Just wait a moment."))
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

		return HookResult.Continue;
	}
}

