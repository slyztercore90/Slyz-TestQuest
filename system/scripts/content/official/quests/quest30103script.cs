//--- Melia Script -----------------------------------------------------------
// Research of Spirits and Emotions [Linker Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(30103)]
public class Quest30103Script : QuestScript
{
	protected override void Load()
	{
		SetId(30103);
		SetName("Research of Spirits and Emotions [Linker Advancement]");
		SetDescription("Talk to the Linker Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_LINKER_5_1_select", "JOB_2_LINKER_5_1", "I'll help you", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_2_LINKER_5_1_agree");
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
			if (character.Inventory.HasItem("JOB_2_LINKER_5_1_ITEM_01", 20) && character.Inventory.HasItem("JOB_2_LINKER_5_1_ITEM_02", 20))
			{
				character.Inventory.RemoveItem("JOB_2_LINKER_5_1_ITEM_01", 20);
				character.Inventory.RemoveItem("JOB_2_LINKER_5_1_ITEM_02", 20);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_2_LINKER_5_1_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

