//--- Melia Script -----------------------------------------------------------
// Security Guard's Favor (2)
//--- Description -----------------------------------------------------------
// Quest to Look for the Security Guard.
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

[QuestScript(19390)]
public class Quest19390Script : QuestScript
{
	protected override void Load()
	{
		SetId(19390);
		SetName("Security Guard's Favor (2)");
		SetDescription("Look for the Security Guard");

		AddPrerequisite(new CompletedPrerequisite("ROKAS31_SUB_02"));
		AddPrerequisite(new LevelPrerequisite(78));

		AddObjective("collect0", "Collect 1 Shabby-Looking Necklace", new CollectItemObjective("ROKAS31_SUB_03_CERT", 1));
		AddDrop("ROKAS31_SUB_03_CERT", 10f, "warleader_hogma");

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Drug_SP2_Q", 30));
		AddReward(new ItemReward("Vis", 1482));

		AddDialogHook("ROKAS31_SUB", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_SUB", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS31_SUB_03_ST", "ROKAS31_SUB_03", "Do not worry I'll collect them", "Take care of such things by yourself"))
			{
				case 1:
					await dialog.Msg("ROKAS31_SUB_03_AC");
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
			if (character.Inventory.HasItem("ROKAS31_SUB_03_CERT", 1))
			{
				character.Inventory.RemoveItem("ROKAS31_SUB_03_CERT", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("ROKAS31_SUB_03_COMP");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

