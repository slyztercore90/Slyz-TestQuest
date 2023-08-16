//--- Melia Script -----------------------------------------------------------
// The Outcome of Choice (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ranger Morvio.
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

[QuestScript(80296)]
public class Quest80296Script : QuestScript
{
	protected override void Load()
	{
		SetId(80296);
		SetName("The Outcome of Choice (4)");
		SetDescription("Talk to Ranger Morvio");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE_87_MQ_12_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_87_MQ_11"));
		AddPrerequisite(new LevelPrerequisite(370));

		AddObjective("kill0", "Kill 1 Pbeta", new KillObjective(58696, 1));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19240));

		AddDialogHook("F_3CMLAKE_87_MQ_12_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_13_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_87_MQ_12_ST", "F_3CMLAKE_87_MQ_12", "Leave it to me.", "I'm too scared."))
			{
				case 1:
					await dialog.Msg("F_3CMLAKE_87_MQ_12_AFST");
					dialog.HideNPC("F_3CMLAKE_87_MQ_12_NPC");
					await dialog.Msg("FadeOutIN/1000");
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

		return HookResult.Continue;
	}
}

