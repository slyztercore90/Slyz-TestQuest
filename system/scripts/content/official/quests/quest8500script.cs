//--- Melia Script -----------------------------------------------------------
// Lizard of Fire
//--- Description -----------------------------------------------------------
// Quest to Check the Barrier Activation Device.
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

[QuestScript(8500)]
public class Quest8500Script : QuestScript
{
	protected override void Load()
	{
		SetId(8500);
		SetName("Lizard of Fire");
		SetDescription("Check the Barrier Activation Device");
		SetTrack("SProgress", "ESuccess", "FTOWER41_SQ_06_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("FTOWER41_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("kill0", "Kill 1 Salamander", new KillObjective(57088, 1));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_MQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

