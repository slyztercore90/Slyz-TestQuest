//--- Melia Script -----------------------------------------------------------
// How to Eat a Kepa (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adrijus.
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

[QuestScript(40511)]
public class Quest40511Script : QuestScript
{
	protected override void Load()
	{
		SetId(40511);
		SetName("How to Eat a Kepa (2)");
		SetDescription("Talk to Adrijus");
		SetTrack("SProgress", "ESuccess", "REMAINS37_1_SQ_031_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("REMAINS37_1_SQ_030"));
		AddPrerequisite(new LevelPrerequisite(168));

		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS37_1_ADRIJUS", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("REMAINS37_1_SQ_031_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

