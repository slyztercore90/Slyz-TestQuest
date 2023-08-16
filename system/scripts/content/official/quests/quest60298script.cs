//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60298)]
public class Quest60298Script : QuestScript
{
	protected override void Load()
	{
		SetId(60298);
		SetName("The Fugitive's Dream (1)");
		SetDescription("Talk to Kupole Grisia");
		SetTrack("SProgress", "ESuccess", "DCAPITAL107_SQ_1_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_8"));
		AddPrerequisite(new LevelPrerequisite(378));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 29000));

		AddDialogHook("DCAPITAL107_SQ_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("DCAPITAL107_SQ_1_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

