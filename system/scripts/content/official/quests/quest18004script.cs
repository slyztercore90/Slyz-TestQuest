//--- Melia Script -----------------------------------------------------------
// Vapsva Vacant Lot's Binding Magic Circle
//--- Description -----------------------------------------------------------
// Quest to Check the binding magic circle in Vapsva Vacant Lot.
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

[QuestScript(18004)]
public class Quest18004Script : QuestScript
{
	protected override void Load()
	{
		SetId(18004);
		SetName("Vapsva Vacant Lot's Binding Magic Circle");
		SetDescription("Check the binding magic circle in Vapsva Vacant Lot");
		SetTrack("SProgress", "ESuccess", "HUEVILLAGE_58_4_MQ04_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_4_MQ01"));
		AddPrerequisite(new LevelPrerequisite(55));

		AddObjective("kill0", "Kill 1 Merge", new KillObjective(47510, 1));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_MQ04_NPC01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

