//--- Melia Script -----------------------------------------------------------
// Chasing the Preacher (11)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(91082)]
public class Quest91082Script : QuestScript
{
	protected override void Load()
	{
		SetId(91082);
		SetName("Chasing the Preacher (11)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new CompletedPrerequisite("EP13_2_DPRISON1_MQ_10"));
		AddPrerequisite(new LevelPrerequisite(460));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 125));

		AddDialogHook("EP13_2_DPRISON1_MQ_NPC_10", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_2_DPRISON1_MQ_11_DLG1", "EP13_2_DPRISON1_MQ_11", "Alright", "I need to take a break"))
			{
				case 1:
					await dialog.Msg("FadeOutIN/1000");
					dialog.HideNPC("EP13_2_DPRISON1_MQ_NPC_10");
					await dialog.Msg("BalloonText/EP13_2_DPRISON1_MQ_11_DLG2/0");
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
			await dialog.Msg("EP13_2_DPRISON1_MQ_11_DLG3");
			await dialog.Msg("EP13_2_DPRISON1_MQ_11_DLG4");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

