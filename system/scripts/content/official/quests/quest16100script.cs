//--- Melia Script -----------------------------------------------------------
// Apiary-invader Sparnas
//--- Description -----------------------------------------------------------
// Quest to Check the beehives at Rododun Apiary.
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

[QuestScript(16100)]
public class Quest16100Script : QuestScript
{
	protected override void Load()
	{
		SetId(16100);
		SetName("Apiary-invader Sparnas");
		SetDescription("Check the beehives at Rododun Apiary");
		SetTrack("SProgress", "ESuccess", "SIAULIAI_46_4_SQ_01_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_46_4_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(160));

		AddObjective("kill0", "Kill 1 Sparnas", new KillObjective(57284, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("SIAULIAI_46_4_BEEHIVE01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

