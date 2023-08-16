//--- Melia Script -----------------------------------------------------------
// The Resentful Soldier's Spirit (1)
//--- Description -----------------------------------------------------------
// Quest to Examine the Soldier's Grave.
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

[QuestScript(50070)]
public class Quest50070Script : QuestScript
{
	protected override void Load()
	{
		SetId(50070);
		SetName("The Resentful Soldier's Spirit (1)");
		SetDescription("Examine the Soldier's Grave");
		SetTrack("SProgress", "ESuccess", "UNDERFORTRESS_67_SQ020_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(207));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(57408, 1));

		AddReward(new ExpReward(713829, 713829));
		AddReward(new ItemReward("expCard10", 5));
		AddReward(new ItemReward("Vis", 7245));

		AddDialogHook("UNDER67_SQ020", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER67_SQ030", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("UNDER_67_SQ020_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

