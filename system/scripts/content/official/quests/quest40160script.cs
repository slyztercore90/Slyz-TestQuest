//--- Melia Script -----------------------------------------------------------
// Desire for Normal Food (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Dalius.
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

[QuestScript(40160)]
public class Quest40160Script : QuestScript
{
	protected override void Load()
	{
		SetId(40160);
		SetName("Desire for Normal Food (2)");
		SetDescription("Talk with Dalius");

		AddPrerequisite(new CompletedPrerequisite("FARM47_4_SQ_090"));
		AddPrerequisite(new LevelPrerequisite(84));

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("FARM47_DALIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_MARIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_4_SQ_100_ST", "FARM47_4_SQ_100", "Alright", "I'm busy so I'll pass"))
			{
				case 1:
					await dialog.Msg("FARM47_4_SQ_100_AC");
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
			await dialog.Msg("FARM47_4_SQ_100_COMP");
			dialog.HideNPC("FARM47_DEVINEMARK");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

