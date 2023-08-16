//--- Melia Script -----------------------------------------------------------
// Legwyn Family's Seal 
//--- Description -----------------------------------------------------------
// Quest to Talk to the Squire Master.
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

[QuestScript(72154)]
public class Quest72154Script : QuestScript
{
	protected override void Load()
	{
		SetId(72154);
		SetName("Legwyn Family's Seal ");
		SetDescription("Talk to the Squire Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_SQUIRE1"));
		AddPrerequisite(new LevelPrerequisite(235));

		AddObjective("collect0", "Collect 10 Broken Legwyn Seal Fragment(s)", new CollectItemObjective("JOB_SQUIRE_6_1_ITEM", 10));
		AddDrop("JOB_SQUIRE_6_1_ITEM", 1f, 57480, 57461, 57462, 57644);

		AddReward(new ItemReward("Point_Stone_100_Q", 2));

		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SQUIRE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_SQUIRE2_DLG1", "MASTER_SQUIRE2", "Accept", "Reject"))
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
			if (character.Inventory.HasItem("JOB_SQUIRE_6_1_ITEM", 10))
			{
				character.Inventory.RemoveItem("JOB_SQUIRE_6_1_ITEM", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_SQUIRE_6_1_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

