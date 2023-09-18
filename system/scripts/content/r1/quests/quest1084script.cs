//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow [Hunter Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Hunter Master.
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

[QuestScript(1084)]
public class Quest1084Script : QuestScript
{
	protected override void Load()
	{
		SetId(1084);
		SetName("Dream Book of the Bow [Hunter Advancement] (2)");
		SetDescription("Talk to the Hunter Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_HUNTER2_1"));

		AddObjective("collect0", "Collect 2 Tough Glizardon Leather(s)", new CollectItemObjective("JOB_HUNTER2_2_ITEM1", 2));
		AddDrop("JOB_HUNTER2_2_ITEM1", 10f, "Glizardon");

		AddReward(new ItemReward("Book4", 1));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_HUNTER2_2_select1", "JOB_HUNTER2_2", "I will get the leather and bring the book", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_HUNTER2_2_agree1");
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

		if (character.Inventory.HasItem("JOB_HUNTER2_2_ITEM1", 2))
		{
			character.Inventory.RemoveItem("JOB_HUNTER2_2_ITEM1", 2);
			await dialog.Msg("EffectLocalNPC/MASTER_QU/archer_buff_skl_Recuperate_circle/1.5/BOT");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_HUNTER2_2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

