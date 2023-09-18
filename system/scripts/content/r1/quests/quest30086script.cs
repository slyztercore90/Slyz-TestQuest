//--- Melia Script -----------------------------------------------------------
// Orsha Retoration Support [Ranger Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Submaster.
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

[QuestScript(30086)]
public class Quest30086Script : QuestScript
{
	protected override void Load()
	{
		SetId(30086);
		SetName("Orsha Retoration Support [Ranger Advancement]");
		SetDescription("Talk to the Ranger Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_RANGER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RANGER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_RANGER_3_1_select", "JOB_2_RANGER_3_1", "I'll help you", "I have other things to do, sorry"))
		{
			case 1:
				await dialog.Msg("JOB_2_RANGER_3_1_agree");
				dialog.UnHideNPC("JOB_2_RANGER_3_1_OBJ_STONE");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		if (character.Inventory.HasItem("JOB_2_RANGER_3_1_ITEM", 10))
		{
			character.Inventory.RemoveItem("JOB_2_RANGER_3_1_ITEM", 10);
			await dialog.Msg("JOB_2_RANGER_3_1_succ");
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("JOB_2_RANGER_3_1_OBJ_STONE");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

