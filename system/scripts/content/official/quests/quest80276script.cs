//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen's Relic (9)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(80276)]
public class Quest80276Script : QuestScript
{
	protected override void Load()
	{
		SetId(80276);
		SetName("Lydia Schaffen's Relic (9)");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack("SPossible", "ESuccess", "F_3CMLAKE_86_MQ_17_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_16"));
		AddPrerequisite(new LevelPrerequisite(366));

		AddObjective("kill0", "Kill 1 Deadborn", new KillObjective(106021, 1));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_16_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_18_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_86_MQ_17_ST", "F_3CMLAKE_86_MQ_17", "I'll go with you.", "I don't have the courage to."))
			{
				case 1:
					dialog.UnHideNPC("F_3CMLAKE_86_MQ_18_NPC");
					dialog.UnHideNPC("F_3CMLAKE_86_MQ_18_NPC_2");
					dialog.UnHideNPC("F_3CMLAKE_86_MQ_18_NPC_3");
					dialog.UnHideNPC("F_3CMLAKE_86_SQ_04_NPC");
					dialog.HideNPC("F_3CMLAKE_86_MQ_02_NPC");
					dialog.HideNPC("F_3CMLAKE_86_MQ_16_NPC");
					dialog.HideNPC("F_3CMLAKE_85_MQ_03_NPC");
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
			await dialog.Msg("F_3CMLAKE_86_MQ_17_SU");
			dialog.HideNPC("F_3CMLAKE_86_MQ_03_NEUTRAL_NPC");
			dialog.UnHideNPC("F_3CMLAKE_86_SQ_04_CONFUSE_NPC");
			dialog.HideNPC("F_3CMLAKE_86_MQ_04_SCOUT_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

