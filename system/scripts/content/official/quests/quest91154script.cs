//--- Melia Script -----------------------------------------------------------
// Into the Assembly Hall
//--- Description -----------------------------------------------------------
// Quest to Enter the Assembly Hall.
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

[QuestScript(91154)]
public class Quest91154Script : QuestScript
{
	protected override void Load()
	{
		SetId(91154);
		SetName("Into the Assembly Hall");
		SetDescription("Enter the Assembly Hall");
		SetTrack("SPossible", "ESuccess", "EP14_2_DCASTLE2_MQ_11_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE2_MQ_10"));
		AddPrerequisite(new LevelPrerequisite(475));

		AddDialogHook("EP14_2_DCASLTE2_PORTAL", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_2_DCASTLE3_RAMIN", "BeforeEnd", BeforeEnd);
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
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

