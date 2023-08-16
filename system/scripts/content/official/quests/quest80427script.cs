//--- Melia Script -----------------------------------------------------------
// Swore to Protect (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Yulia.
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

[QuestScript(80427)]
public class Quest80427Script : QuestScript
{
	protected override void Load()
	{
		SetId(80427);
		SetName("Swore to Protect (1)");
		SetDescription("Talk to Kupole Yulia");
		SetTrack("SPossible", "EPossible", "F_MAPLE_24_2_MQ_01_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_1_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(415));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_MAPLE_242_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_242_MQ_01_NPC", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("F_MAPLE_24_2_MQ_01_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

