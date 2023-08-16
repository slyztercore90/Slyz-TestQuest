//--- Melia Script -----------------------------------------------------------
// Story behind the collapse of the owl
//--- Description -----------------------------------------------------------
// Quest to Observe the Fallen Owl Sculpture.
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

[QuestScript(19400)]
public class Quest19400Script : QuestScript
{
	protected override void Load()
	{
		SetId(19400);
		SetName("Story behind the collapse of the owl");
		SetDescription("Observe the Fallen Owl Sculpture");
		SetTrack("SProgress", "ESuccess", "KATYN7_2_ADD_BOSS_01_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Throneweaver", new KillObjective(41221, 1));

		AddReward(new ExpReward(120624, 120624));
		AddReward(new ItemReward("expCard7", 2));
		AddReward(new ItemReward("Vis", 11088891));

		AddDialogHook("KATYN7_2_FALL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

