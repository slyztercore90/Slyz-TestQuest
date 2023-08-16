//--- Melia Script -----------------------------------------------------------
// Good Use For a Wand (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Aden.
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

[QuestScript(80202)]
public class Quest80202Script : QuestScript
{
	protected override void Load()
	{
		SetId(80202);
		SetName("Good Use For a Wand (2)");
		SetDescription("Talk with Priest Aden");

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_SQ07"));
		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_SQ03", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL53_SQ08_select01", "CHATHEDRAL53_SQ08", "I'll try to find them", "I'll think about it."))
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
			if (character.Inventory.HasItem("CHATHEDRAL53_SQ08_ITEM", 1))
			{
				character.Inventory.RemoveItem("CHATHEDRAL53_SQ08_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CHATHEDRAL53_SQ08_succ01");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

