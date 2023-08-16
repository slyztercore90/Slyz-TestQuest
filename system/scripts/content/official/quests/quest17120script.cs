//--- Melia Script -----------------------------------------------------------
// Finding the Lever Handle Latches
//--- Description -----------------------------------------------------------
// Quest to Talk to Watcher Gilbert.
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

[QuestScript(17120)]
public class Quest17120Script : QuestScript
{
	protected override void Load()
	{
		SetId(17120);
		SetName("Finding the Lever Handle Latches");
		SetDescription("Talk to Watcher Gilbert");

		AddPrerequisite(new LevelPrerequisite(26));

		AddReward(new ExpReward(5372, 5372));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 364));

		AddDialogHook("GELE571_NPC_GILBERT", "BeforeStart", BeforeStart);
		AddDialogHook("GELE571_NPC_GILBERT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE571_MQ_03_01", "GELE571_MQ_03", "I'll bring it ", "I don't have time"))
			{
				case 1:
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
			await dialog.Msg("GELE571_MQ_03_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

