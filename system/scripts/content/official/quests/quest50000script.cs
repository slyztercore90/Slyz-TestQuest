//--- Melia Script -----------------------------------------------------------
// Disintegration (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Priest Benedict.
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

[QuestScript(50000)]
public class Quest50000Script : QuestScript
{
	protected override void Load()
	{
		SetId(50000);
		SetName("Disintegration (1)");
		SetDescription("Talk to Priest Benedict");

		AddPrerequisite(new LevelPrerequisite(138));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3450));

		AddDialogHook("CHATHEDRAL53_SQ02", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL53_SQ05_select01", "CHATHEDRAL53_SQ05", "I can get them", "I'm not interested"))
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
			if (character.Inventory.HasItem("CATHEDRAL53_SQ_SAMPLE01", 12))
			{
				character.Inventory.RemoveItem("CATHEDRAL53_SQ_SAMPLE01", 12);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CHATHEDRAL53_SQ05_succ01");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

