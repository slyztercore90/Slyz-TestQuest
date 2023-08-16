//--- Melia Script -----------------------------------------------------------
// The enemy is also preparing
//--- Description -----------------------------------------------------------
// Quest to Investigate the area in front of the door.
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

[QuestScript(70601)]
public class Quest70601Script : QuestScript
{
	protected override void Load()
	{
		SetId(70601);
		SetName("The enemy is also preparing");
		SetDescription("Investigate the area in front of the door");
		SetTrack("SPossible", "ESuccess", "ABBEY41_6_SQ02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("ABBEY41_6_SQ01"));
		AddPrerequisite(new LevelPrerequisite(274));

		AddDialogHook("ABBEY416_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY416_SQ_02", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("ABBEY416_SQ_02_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

