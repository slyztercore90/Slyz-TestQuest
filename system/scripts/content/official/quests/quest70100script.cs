//--- Melia Script -----------------------------------------------------------
// An Unlucky Day
//--- Description -----------------------------------------------------------
// Quest to Inspect the Mysterious Trap .
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

[QuestScript(70100)]
public class Quest70100Script : QuestScript
{
	protected override void Load()
	{
		SetId(70100);
		SetName("An Unlucky Day");
		SetDescription("Inspect the Mysterious Trap ");
		SetTrack("SProgress", "ESuccess", "THORN39_2_MQ01_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(173));

		AddDialogHook("THORN392_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_02", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("THORN39_2_MQ_01_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

