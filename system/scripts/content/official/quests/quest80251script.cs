//--- Melia Script -----------------------------------------------------------
// The Evil Monster (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Bern.
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

[QuestScript(80251)]
public class Quest80251Script : QuestScript
{
	protected override void Load()
	{
		SetId(80251);
		SetName("The Evil Monster (3)");
		SetDescription("Talk to Resistance Adjutant Bern");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE_85_MQ_09_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_85_MQ_08_1"));
		AddPrerequisite(new LevelPrerequisite(362));

		AddObjective("kill0", "Kill 1 Hydra", new KillObjective(106020, 1));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_10_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_85_MQ_09_ST", "F_3CMLAKE_85_MQ_09", "I'll get going right away.", "I'm too afraid."))
			{
				case 1:
					await dialog.Msg("F_3CMLAKE_85_MQ_09_AFST");
					dialog.UnHideNPC("F_3CMLAKE_85_MQ_10_NPC");
					dialog.UnHideNPC("F_3CMLAKE_85_MQ_10_NPC1");
					dialog.UnHideNPC("F_3CMLAKE_85_MQ_10_NPC2");
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
			await dialog.Msg("F_3CMLAKE_85_MQ_09_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

