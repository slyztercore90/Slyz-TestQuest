//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen's Relic (2)
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

[QuestScript(80269)]
public class Quest80269Script : QuestScript
{
	protected override void Load()
	{
		SetId(80269);
		SetName("Lydia Schaffen's Relic (2)");
		SetDescription("Talk to Resistance Adjutant Lehon");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "F_3CMLAKE_86_MQ_10_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_09"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_10_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_10_ST", "F_3CMLAKE_86_MQ_10", "Let's move.", "It's too far away."))
		{
			case 1:
				dialog.HideNPC("F_3CMLAKE_86_MQ_03_NPC");
				await Task.Delay(500);
				// Func/SCR_F_3CMLAKE_86_MQ_10_RUNNPC;
				dialog.UnHideNPC("F_3CMLAKE_86_FOLLOWER");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("F_3CMLAKE86_MQ10_ITEM", 1))
		{
			character.Inventory.RemoveItem("F_3CMLAKE86_MQ10_ITEM", 1);
			await dialog.Msg("F_3CMLAKE_86_MQ_10_SU");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

