//--- Melia Script -----------------------------------------------------------
// Eliminate the Small Gaps
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Sigita.
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

[QuestScript(60041)]
public class Quest60041Script : QuestScript
{
	protected override void Load()
	{
		SetId(60041);
		SetName("Eliminate the Small Gaps");
		SetDescription("Talk to Kupole Sigita");

		AddPrerequisite(new CompletedPrerequisite("VPRISON515_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(163));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 4890));

		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON515_MQ_SIGITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("VPRISON515_SQ_03_01", "VPRISON515_SQ_03", "I will get rid of it", "I need some more time"))
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
			await dialog.Msg("VPRISON515_SQ_03_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

