//--- Melia Script -----------------------------------------------------------
// Curse of Sloth - Curse
//--- Description -----------------------------------------------------------
// Quest to Spoiled Tree Root Crystal at the right side of the Pilgrim's Tomb.
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

[QuestScript(19580)]
public class Quest19580Script : QuestScript
{
	protected override void Load()
	{
		SetId(19580);
		SetName("Curse of Sloth - Curse");
		SetDescription("Spoiled Tree Root Crystal at the right side of the Pilgrim's Tomb");
		SetTrack("SProgress", "ESuccess", "PILGRIM47_SQ_040_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(124));

		AddObjective("kill0", "Kill 1 Cactusvel", new KillObjective(57297, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3100));

		AddDialogHook("PILGRIM47_CRYST04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

