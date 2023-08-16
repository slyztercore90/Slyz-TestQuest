//--- Melia Script -----------------------------------------------------------
// Surprise Attack
//--- Description -----------------------------------------------------------
// Quest to Check the Karuna Altar.
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

[QuestScript(20318)]
public class Quest20318Script : QuestScript
{
	protected override void Load()
	{
		SetId(20318);
		SetName("Surprise Attack");
		SetDescription("Check the Karuna Altar");
		SetTrack("SProgress", "ESuccess", "CHATHEDRAL54_SQ05_PART2_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(142));

		AddObjective("kill0", "Kill 1 Riteris", new KillObjective(57311, 1));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3692));

		AddDialogHook("CHATHEDRAL54_MQ04_PART2", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

