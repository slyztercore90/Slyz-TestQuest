//--- Melia Script -----------------------------------------------------------
// Flame Fusion Room Archon 
//--- Description -----------------------------------------------------------
// Quest to &Check the Flame Fusion Machine.
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

[QuestScript(8504)]
public class Quest8504Script : QuestScript
{
	protected override void Load()
	{
		SetId(8504);
		SetName("Flame Fusion Room Archon ");
		SetDescription("&Check the Flame Fusion Machine");
		SetTrack("SProgress", "ESuccess", "FTOWER42_SQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("FTOWER42_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(116));

		AddObjective("kill0", "Kill 1 Archon", new KillObjective(57096, 1));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 5));
		AddReward(new ItemReward("Vis", 2784));

		AddDialogHook("FTOWER42_MQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

