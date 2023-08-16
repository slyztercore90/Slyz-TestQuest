//--- Melia Script -----------------------------------------------------------
// Dusk and Dawn (2)
//--- Description -----------------------------------------------------------
// Quest to Move to the Passage of Hope.
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

[QuestScript(72261)]
public class Quest72261Script : QuestScript
{
	protected override void Load()
	{
		SetId(72261);
		SetName("Dusk and Dawn (2)");
		SetDescription("Move to the Passage of Hope");
		SetTrack("SProgress", "ESuccess", "EP12_FINALE_02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_FINALE_01"));
		AddPrerequisite(new LevelPrerequisite(446));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_FINALE_DIRECTION_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_FINALE_RAIMA01", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("EP12_FINALE_02_DLG05");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

