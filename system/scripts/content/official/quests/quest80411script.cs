//--- Melia Script -----------------------------------------------------------
// Flowers and Butterflies (4)
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

[QuestScript(80411)]
public class Quest80411Script : QuestScript
{
	protected override void Load()
	{
		SetId(80411);
		SetName("Flowers and Butterflies (4)");
		SetDescription("Talk to Kupole Astra");

		AddPrerequisite(new CompletedPrerequisite("F_MAPLE_24_3_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(408));

		AddReward(new ExpReward(146411072, 146411072));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("F_MAPLE_243_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_MAPLE_243_MQ_05_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_MAPLE_24_3_MQ_04_ST", "F_MAPLE_24_3_MQ_04", "We should get a move on.", "That sounds way too dangerous."))
			{
				case 1:
					await dialog.Msg("FadeOutIN/2000");
					dialog.HideNPC("F_MAPLE_243_MQ_01_NPC");
					dialog.UnHideNPC("F_MAPLE_243_MQ_05_NPC");
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
			await dialog.Msg("F_MAPLE_24_3_MQ_04_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

