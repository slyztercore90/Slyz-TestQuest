//--- Melia Script -----------------------------------------------------------
// Defeat the attacking monsters
//--- Description -----------------------------------------------------------
// Quest to Look at the pothole.
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

[QuestScript(20068)]
public class Quest20068Script : QuestScript
{
	protected override void Load()
	{
		SetId(20068);
		SetName("Defeat the attacking monsters");
		SetDescription("Look at the pothole");
		SetTrack("SPossible", "ESuccess", "KATYN13_1_KEY_SUB1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(112));

		AddObjective("kill0", "Kill 2 Green Pokuborn(s)", new KillObjective(400084, 2));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("food_018", 3));
		AddReward(new ItemReward("Vis", 2688));

		AddDialogHook("KATYN13_1_KEY_SUB1_TRUFFLE", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_KEY_SUB1_TRUFFLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.AddonMessage("NOTICE_Dm_Clear", "You found a Truffle from the dug area!", 5);
			await Task.Delay(5000);
			dialog.HideNPC("KATYN13_1_KEY_SUB1_TRUFFLE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

