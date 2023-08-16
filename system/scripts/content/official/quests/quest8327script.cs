//--- Melia Script -----------------------------------------------------------
// The Wandering Soul (3)
//--- Description -----------------------------------------------------------
// Quest to Check the suspicious location.
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

[QuestScript(8327)]
public class Quest8327Script : QuestScript
{
	protected override void Load()
	{
		SetId(8327);
		SetName("The Wandering Soul (3)");
		SetDescription("Check the suspicious location");
		SetTrack("SProgress", "ESuccess", "KATYN18_MQ_21_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_20"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KATYN18_MQ_21_TRACK", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_GOD", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("KATYN18_MQ_21_03");
			await dialog.Msg("FadeOutIN/1500");
			dialog.HideNPC("KATYN18_GOD");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

