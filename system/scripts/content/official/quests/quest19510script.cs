//--- Melia Script -----------------------------------------------------------
// Necklace of Gluttony
//--- Description -----------------------------------------------------------
// Quest to Look through the lump of rotten meat at Ascetic Sanctuary..
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

[QuestScript(19510)]
public class Quest19510Script : QuestScript
{
	protected override void Load()
	{
		SetId(19510);
		SetName("Necklace of Gluttony");
		SetDescription("Look through the lump of rotten meat at Ascetic Sanctuary.");
		SetTrack("SProgress", "ESuccess", "PILGRIM46_SQ_080_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM46_SQ_060"));
		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(57296, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("NECK01_132", 1));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("PILGRIM46_BOSS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

