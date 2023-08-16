//--- Melia Script -----------------------------------------------------------
// The Man Who Destroyed the Tower
//--- Description -----------------------------------------------------------
// Quest to Check the destroyed seal tower.
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

[QuestScript(16710)]
public class Quest16710Script : QuestScript
{
	protected override void Load()
	{
		SetId(16710);
		SetName("The Man Who Destroyed the Tower");
		SetDescription("Check the destroyed seal tower");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_46_1_SQ_02_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_1_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(169));

		AddObjective("kill0", "Kill 1 Manticen", new KillObjective(57289, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 5070));

		AddDialogHook("SIAULIAI_46_1_DEADTREE01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

