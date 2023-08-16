//--- Melia Script -----------------------------------------------------------
// Taniel the Second's Royal Mausoleum
//--- Description -----------------------------------------------------------
// Quest to Observe the device's reaction.
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

[QuestScript(70847)]
public class Quest70847Script : QuestScript
{
	protected override void Load()
	{
		SetId(70847);
		SetName("Taniel the Second's Royal Mausoleum");
		SetDescription("Observe the device's reaction");
		SetTrack("SPossible", "ESuccess", "WHITETREES23_3_SQ08_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_3_SQ07"));
		AddPrerequisite(new LevelPrerequisite(323));

		AddDialogHook("WHITETREES233_SQ_08_1", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES233_SQ_08", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("WHITETREES233_SQ_08_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

