//--- Melia Script -----------------------------------------------------------
// Purification of the Stream, Recovery of the Tree (3)
//--- Description -----------------------------------------------------------
// Quest to The appearance of an evil energy.
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

[QuestScript(19950)]
public class Quest19950Script : QuestScript
{
	protected override void Load()
	{
		SetId(19950);
		SetName("Purification of the Stream, Recovery of the Tree (3)");
		SetDescription("The appearance of an evil energy");
		SetTrack("SProgress", "ESuccess", "PILGRIM52_SQ_090_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM52_SQ_081"));
		AddPrerequisite(new LevelPrerequisite(133));

		AddObjective("kill0", "Kill 1 Succubus", new KillObjective(57445, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("PILGRIM52_ITEM_09", 1));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM_SUCCUBUS", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

