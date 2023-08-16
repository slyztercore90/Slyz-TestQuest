//--- Melia Script -----------------------------------------------------------
// Hidden Treasure Chest
//--- Description -----------------------------------------------------------
// Quest to Find the hidden treasure.
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

[QuestScript(8421)]
public class Quest8421Script : QuestScript
{
	protected override void Load()
	{
		SetId(8421);
		SetName("Hidden Treasure Chest");
		SetDescription("Find the hidden treasure");
		SetTrack("SProgress", "ESuccess", "ZACHA5F_EQ_03_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(94));

		AddObjective("kill0", "Kill 7 Medakia(s)", new KillObjective(400821, 7));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1880));

		AddDialogHook("ZACHA5F_EQ_03", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

