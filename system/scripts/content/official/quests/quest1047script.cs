//--- Melia Script -----------------------------------------------------------
// Netherbovine's Attack
//--- Description -----------------------------------------------------------
// Quest to Defeat Netherbovine.
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

[QuestScript(1047)]
public class Quest1047Script : QuestScript
{
	protected override void Load()
	{
		SetId(1047);
		SetName("Netherbovine's Attack");
		SetDescription("Defeat Netherbovine");
		SetTrack("SProgress", "ESuccess", "MINE_3_RESQUE3_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(21));

		AddObjective("kill0", "Kill 1 Netherbovine", new KillObjective(41237, 1));

		AddReward(new ExpReward(8058, 8058));
		AddReward(new ItemReward("expCard2", 3));
		AddReward(new ItemReward("FOOT02_115", 1));
		AddReward(new ItemReward("Vis", 294));

		AddDialogHook("MINE_3_RESQUE3", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

