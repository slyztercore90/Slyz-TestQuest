//--- Melia Script -----------------------------------------------------------
// Beholder of Sesija Entrance
//--- Description -----------------------------------------------------------
// Quest to Beholder of Sesija Entrance.
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

[QuestScript(9001)]
public class Quest9001Script : QuestScript
{
	protected override void Load()
	{
		SetId(9001);
		SetName("Beholder of Sesija Entrance");
		SetDescription("Beholder of Sesija Entrance");
		SetTrack("SProgress", "ESuccess", "ROKAS31_REXITHER1_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("ROKAS31_PACT_END"));
		AddPrerequisite(new LevelPrerequisite(78));

		AddObjective("kill0", "Kill 1 Bearkaras", new KillObjective(57080, 1));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 68));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_REXITHER1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

