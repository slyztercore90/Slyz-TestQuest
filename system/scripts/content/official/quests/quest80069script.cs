//--- Melia Script -----------------------------------------------------------
// Support for the Greater Justice (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80069)]
public class Quest80069Script : QuestScript
{
	protected override void Load()
	{
		SetId(80069);
		SetName("Support for the Greater Justice (2)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_4"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_35_1_SQ_5_start", "SIAULIAI_35_1_SQ_5", "Ask if this is it", "I didn't see it"))
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
			if (character.Inventory.HasItem("SIAULIAI_35_1_SQ_POTION", 1))
			{
				character.Inventory.RemoveItem("SIAULIAI_35_1_SQ_POTION", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("SIAULIAI_35_1_SQ_5_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

