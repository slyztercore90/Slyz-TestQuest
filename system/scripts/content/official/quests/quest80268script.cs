//--- Melia Script -----------------------------------------------------------
// Lydia Schaffen's Relic (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Ramunas.
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

[QuestScript(80268)]
public class Quest80268Script : QuestScript
{
	protected override void Load()
	{
		SetId(80268);
		SetName("Lydia Schaffen's Relic (1)");
		SetDescription("Talk to Elder Ramunas");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_08"));
		AddPrerequisite(new LevelPrerequisite(366));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_03_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_86_MQ_09_ST", "F_3CMLAKE_86_MQ_09", "I'll try to restore it.", "That's not my job."))
			{
				case 1:
					await dialog.Msg("F_3CMLAKE_86_MQ_09_AFST");
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("F_3CMLAKE_86_MQ_09_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

