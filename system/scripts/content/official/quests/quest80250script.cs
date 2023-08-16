//--- Melia Script -----------------------------------------------------------
// The Evil Monster (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(80250)]
public class Quest80250Script : QuestScript
{
	protected override void Load()
	{
		SetId(80250);
		SetName("The Evil Monster (1)");
		SetDescription("Talk to Resistance Deputy Commander Kron");
		SetTrack("SPossible", "EPossible", "F_3CMLAKE_85_MQ_08_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(362));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_85_MQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_85_MQ_08_ST", "F_3CMLAKE_85_MQ_08", "I've normalized the Water Facility.", "I've nothing to tell."))
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
			await dialog.Msg("F_3CMLAKE_85_MQ_08_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

