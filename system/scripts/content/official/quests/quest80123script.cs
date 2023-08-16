//--- Melia Script -----------------------------------------------------------
// Brainwashed Tribe (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Trija.
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

[QuestScript(80123)]
public class Quest80123Script : QuestScript
{
	protected override void Load()
	{
		SetId(80123);
		SetName("Brainwashed Tribe (1)");
		SetDescription("Talk to Kupole Trija");

		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_5_MQ_10"));
		AddPrerequisite(new LevelPrerequisite(287));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LIMESTONE_52_1_SQ_1_start", "LIMESTONE_52_1_SQ_1", "I'll get it", "I don't think that will work."))
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
			if (character.Inventory.HasItem("LIMESTONE_52_1_SQ_1_NECK", 10))
			{
				character.Inventory.RemoveItem("LIMESTONE_52_1_SQ_1_NECK", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("LIMESTONE_52_1_SQ_1_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

