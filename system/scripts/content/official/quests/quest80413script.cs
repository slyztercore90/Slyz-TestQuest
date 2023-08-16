//--- Melia Script -----------------------------------------------------------
// Medeina's Traces (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Astra.
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

[QuestScript(80413)]
public class Quest80413Script : QuestScript
{
	protected override void Load()
	{
		SetId(80413);
		SetName("Medeina's Traces (1)");
		SetDescription("Talk to Kupole Astra");
		SetTrack("SPossible", "EPossible", "F_MAPLE_24_3_MQ_06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_3_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(408));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_MAPLE_243_MQ_05_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_243_MQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_MAPLE_24_3_MQ_06_ST", "F_MAPLE_24_3_MQ_06", "Let's get going.", "That's not something I want to do."))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("F_MAPLE_24_3_MQ_06_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

