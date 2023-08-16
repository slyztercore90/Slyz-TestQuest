//--- Melia Script -----------------------------------------------------------
// Not As Intended (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Supply Officer.
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

[QuestScript(20131)]
public class Quest20131Script : QuestScript
{
	protected override void Load()
	{
		SetId(20131);
		SetName("Not As Intended (2)");
		SetDescription("Talk to the Supply Officer");
		SetTrack("SPossible", "ESuccess", "ACT2_DISS1_2_BOSS_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("ACT2_DISS1"));
		AddPrerequisite(new LevelPrerequisite(7));

		AddObjective("kill0", "Kill 1 Tutu", new KillObjective(41210, 1));

		AddReward(new ExpReward(500, 500));
		AddReward(new ItemReward("expCard1", 1));
		AddReward(new ItemReward("Vis", 91));

		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("SIAUL_EAST_SUPPLY_MANAGER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("ACT2_DISS1_2_BOSS_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAUL_EAST_RECLAIM6");
	}
}

