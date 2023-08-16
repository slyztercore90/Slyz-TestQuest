//--- Melia Script -----------------------------------------------------------
// Trace Race (3)
//--- Description -----------------------------------------------------------
// Quest to Defeat the demons.
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

[QuestScript(90143)]
public class Quest90143Script : QuestScript
{
	protected override void Load()
	{
		SetId(90143);
		SetName("Trace Race (3)");
		SetDescription("Defeat the demons");
		SetTrack("SPossible", "ESuccess", "F_DCAPITAL_20_6_SQ_40_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_30"));
		AddPrerequisite(new LevelPrerequisite(295));

		AddObjective("kill0", "Kill 8 Blue Woodluwa(s) or Green Ellomago(s)", new KillObjective(8, 58492, 58491));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_SQ_40", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("F_DCAPITAL_20_6_SQ_40_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_DCAPITAL_20_6_SQ_50");
	}
}

