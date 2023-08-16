//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen's Relic (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Lehon.
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

[QuestScript(80273)]
public class Quest80273Script : QuestScript
{
	protected override void Load()
	{
		SetId(80273);
		SetName("Lydia Schaffen's Relic (6)");
		SetDescription("Talk to Resistance Adjutant Lehon");
		SetTrack("SPossible", "ESuccess", "F_3CMLAKE_86_MQ_14_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_13"));
		AddPrerequisite(new LevelPrerequisite(366));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_15_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_15_NPC", "BeforeEnd", BeforeEnd);
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
			if (character.Inventory.HasItem("F_3CMLAKE86_MQ14_ITEM", 1))
			{
				character.Inventory.RemoveItem("F_3CMLAKE86_MQ14_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("F_3CMLAKE_86_MQ_14_SU");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

