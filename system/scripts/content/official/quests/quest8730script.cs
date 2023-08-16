//--- Melia Script -----------------------------------------------------------
// The Entrance of the Cathedral (3)
//--- Description -----------------------------------------------------------
// Quest to Open the Gate.
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

[QuestScript(8730)]
public class Quest8730Script : QuestScript
{
	protected override void Load()
	{
		SetId(8730);
		SetName("The Entrance of the Cathedral (3)");
		SetDescription("Open the Gate");
		SetTrack("SProgress", "ESuccess", "CHAPLE576_MQ_04_AFTER", 500);

		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(44));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));

		AddDialogHook("CHAPLE576_MQ_04", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL576_DONATAS", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("CHAPLE576_MQ_04_03_1");
			dialog.UnHideNPC("CHAPEL576_GELE574");
			dialog.HideNPC("GELE574_ARUNE_1");
			dialog.UnHideNPC("GELE574_TO_CHAPEL576");
			await dialog.Msg("NPCAin/CHAPLE576_MQ_04/ASTD/1");
			dialog.UnHideNPC("CHAPLE577_ARUNE_01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

