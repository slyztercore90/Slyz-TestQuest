//--- Melia Script -----------------------------------------------------------
// Going Below the Shadow (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(60248)]
public class Quest60248Script : QuestScript
{
	protected override void Load()
	{
		SetId(60248);
		SetName("Going Below the Shadow (1)");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new CompletedPrerequisite("FANTASYLIB481_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(338));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 5));

		AddDialogHook("FLIBRARY482_NERINGA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("FLIBRARY482_NERINGA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FANTASYLIB482_MQ_1_1", "FANTASYLIB482_MQ_1", "I'll take care of it", "I'll wait a little bit"))
			{
				case 1:
					await dialog.Msg("FANTASYLIB482_MQ_1_1_1");
					dialog.UnHideNPC("FANTASYLIB482_MQ_1_NPC");
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
			await dialog.Msg("FANTASYLIB482_MQ_1_3");
			dialog.HideNPC("FANTASYLIB482_MQ_1_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

