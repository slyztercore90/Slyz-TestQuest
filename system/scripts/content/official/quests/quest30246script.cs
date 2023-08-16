//--- Melia Script -----------------------------------------------------------
// Operation Outer Wall Core Retrieval (4)
//--- Description -----------------------------------------------------------
// Quest to Check the Defensive Wall Maintainer.
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

[QuestScript(30246)]
public class Quest30246Script : QuestScript
{
	protected override void Load()
	{
		SetId(30246);
		SetName("Operation Outer Wall Core Retrieval (4)");
		SetDescription("Check the Defensive Wall Maintainer");
		SetTrack("SProgress", "ESuccess", "CASTLE_20_1_SQ_4_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("CASTLE_20_1_SQ_3"));
		AddPrerequisite(new LevelPrerequisite(285));

		AddObjective("kill0", "Kill 8 Akhlass Petal(s)", new KillObjective(58609, 8));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 11970));

		AddDialogHook("CASTLE_20_1_OBJ_4", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

