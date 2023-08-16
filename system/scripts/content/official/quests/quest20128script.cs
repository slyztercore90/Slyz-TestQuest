//--- Melia Script -----------------------------------------------------------
// The Road Back 
//--- Description -----------------------------------------------------------
// Quest to On the road back.
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

[QuestScript(20128)]
public class Quest20128Script : QuestScript
{
	protected override void Load()
	{
		SetId(20128);
		SetName("The Road Back ");
		SetDescription("On the road back");
		SetTrack("SPossible", "ESuccess", "SIAUL_WEST_LAIMONAS3_2_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_LAIMONAS1"));
		AddPrerequisite(new LevelPrerequisite(4));

		AddObjective("kill0", "Kill 1 Mushcaria", new KillObjective(41217, 1));

		AddReward(new ExpReward(3000, 3000));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 6));
		AddReward(new ItemReward("Drug_SP1_Q", 3));
		AddReward(new ItemReward("Vis", 52));

		AddDialogHook("F_SIAULIAI_WEST_EV_55_001", "BeforeStart", BeforeStart);
		AddDialogHook("F_SIAULIAI_WEST_EV_55_001", "BeforeEnd", BeforeEnd);
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

		return HookResult.Continue;
	}
}

