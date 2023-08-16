//--- Melia Script -----------------------------------------------------------
// Mysterious Slate (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Crystal Pillar in the Closed Area.
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

[QuestScript(20050)]
public class Quest20050Script : QuestScript
{
	protected override void Load()
	{
		SetId(20050);
		SetName("Mysterious Slate (1)");
		SetDescription("Check the Crystal Pillar in the Closed Area");
		SetTrack("SProgress", "ESuccess", "MINE_3_BOSS_2boss", 4000);

		AddPrerequisite(new CompletedPrerequisite("MINE_3_RESQUE1"));
		AddPrerequisite(new LevelPrerequisite(21));

		AddReward(new ExpReward(67150, 67150));
		AddReward(new ItemReward("stonetablet01_noread", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 7));
		AddReward(new ItemReward("Vis", 1764));

		AddDialogHook("CMINE6_TO_KATYN7_1_START", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

