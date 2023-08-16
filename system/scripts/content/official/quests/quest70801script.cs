//--- Melia Script -----------------------------------------------------------
// Trap after trap(1)
//--- Description -----------------------------------------------------------
// Quest to Deal with the trapped monsters.
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

[QuestScript(70801)]
public class Quest70801Script : QuestScript
{
	protected override void Load()
	{
		SetId(70801);
		SetName("Trap after trap(1)");
		SetDescription("Deal with the trapped monsters");
		SetTrack("SPossible", "ESuccess", "WHITETREES23_1_SQ02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ01"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddObjective("kill0", "Kill 5 Kugheri Tot(s)", new KillObjective(58546, 5));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("WHITETREES231_SQ_02", "BeforeEnd", BeforeEnd);
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

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WHITETREES23_1_SQ03");
	}
}

