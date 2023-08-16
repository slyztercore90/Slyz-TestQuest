//--- Melia Script -----------------------------------------------------------
// Destroy the Tombstones of Nestopa (1)
//--- Description -----------------------------------------------------------
// Quest to Destroy the tombstone of Nestospa at Usas Hill.
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

[QuestScript(41030)]
public class Quest41030Script : QuestScript
{
	protected override void Load()
	{
		SetId(41030);
		SetName("Destroy the Tombstones of Nestopa (1)");
		SetDescription("Destroy the tombstone of Nestospa at Usas Hill");
		SetTrack("SProgress", "ESuccess", "PILGRIM_36_2_SQ_030_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_020"));
		AddPrerequisite(new LevelPrerequisite(106));

		AddObjective("kill0", "Kill 1 Sanctum Object", new KillObjective(152008, 1));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_SHRINE_REAL", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

