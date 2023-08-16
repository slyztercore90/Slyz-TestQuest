//--- Melia Script -----------------------------------------------------------
// Ceremony for the Goddess
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Verta.
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

[QuestScript(90077)]
public class Quest90077Script : QuestScript
{
	protected override void Load()
	{
		SetId(90077);
		SetName("Ceremony for the Goddess");
		SetDescription("Talk to Loremaster Verta");
		SetTrack("SProgress", "ESuccess", "CORAL_32_2_SQ_9_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_8"));
		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("CORAL_32_2_BERTA2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_BERTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CORAL_32_2_SQ_9_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

