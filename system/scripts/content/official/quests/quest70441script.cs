//--- Melia Script -----------------------------------------------------------
// Chasing Lord Delmore (2)
//--- Description -----------------------------------------------------------
// Quest to Chase Delmore Rephaim to the Outskirts Central Plaza.
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

[QuestScript(70441)]
public class Quest70441Script : QuestScript
{
	protected override void Load()
	{
		SetId(70441);
		SetName("Chasing Lord Delmore (2)");
		SetDescription("Chase Delmore Rephaim to the Outskirts Central Plaza");
		SetTrack("SPossible", "ESuccess", "SCR_CASTLE653_MQ_02_TRACKSTART", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(368565, 368565));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_02", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_03", "BeforeEnd", BeforeEnd);
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
}

