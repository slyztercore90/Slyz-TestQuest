//--- Melia Script -----------------------------------------------------------
// Approval (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon King Baiga.
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

[QuestScript(80450)]
public class Quest80450Script : QuestScript
{
	protected override void Load()
	{
		SetId(80450);
		SetName("Approval (2)");
		SetDescription("Talk to Demon King Baiga");
		SetTrack("SProgress", "ESuccess", "F_CASTLE_97_MQ_02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_97_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(426));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24708));

		AddDialogHook("F_CASTLE_97_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_97_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_CASTLE_97_MQ_02_ST", "F_CASTLE_97_MQ_02", "Alright", "That's not something I want to do."))
			{
				case 1:
					dialog.HideNPC("F_CASTLE_97_MQ_01_NPC");
					await dialog.Msg("FadeOutIN/2000");
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
			await dialog.Msg("F_CASTLE_97_MQ_02_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

