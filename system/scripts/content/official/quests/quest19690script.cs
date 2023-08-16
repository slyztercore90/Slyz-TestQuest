//--- Melia Script -----------------------------------------------------------
// Condensed Anger
//--- Description -----------------------------------------------------------
// Quest to The altar near the Forest of Prayer.
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

[QuestScript(19690)]
public class Quest19690Script : QuestScript
{
	protected override void Load()
	{
		SetId(19690);
		SetName("Condensed Anger");
		SetDescription("The altar near the Forest of Prayer");
		SetTrack("SProgress", "ESuccess", "PILGRIM50_SQ_080_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(127));

		AddObjective("collect0", "Collect 1 Condensed Anger", new CollectItemObjective("PILGRIM50_ITEM_06", 1));
		AddDrop("PILGRIM50_ITEM_06", 10f, "boss_Teraox_Q1");

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3175));

		AddDialogHook("PILGRIM50_ALTAR02", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

