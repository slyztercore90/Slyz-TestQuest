//--- Melia Script -----------------------------------------------------------
// The Dream Bow Book (2)
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

[QuestScript(72133)]
public class Quest72133Script : QuestScript
{
	protected override void Load()
	{
		SetId(72133);
		SetName("The Dream Bow Book (2)");
		SetDescription("Talk to the Hunter Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_HUNTER1_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddObjective("collect0", "Collect 2 Tough Glizardon Leather(s)", new CollectItemObjective("JOB_HUNTER2_2_ITEM1", 2));
		AddDrop("JOB_HUNTER2_2_ITEM1", 10f, "Glizardon");

		AddReward(new ItemReward("MASTER_HUNTER1_2_ITEM", 1));

		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_QU", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HUNTER2_2_select1", "MASTER_HUNTER1_2", "I will get the leather and bring the book", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_HUNTER2_2_agree1");
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
			if (character.Inventory.HasItem("JOB_HUNTER2_2_ITEM1", 2))
			{
				character.Inventory.RemoveItem("JOB_HUNTER2_2_ITEM1", 2);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/MASTER_QU/archer_buff_skl_Recuperate_circle/1.5/BOT");
				await dialog.Msg("MASTER_HUNTER1_2_DLG1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

