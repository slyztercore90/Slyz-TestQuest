//--- Melia Script -----------------------------------------------------------
// Suspicious Movement (3)
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

[QuestScript(90172)]
public class Quest90172Script : QuestScript
{
	protected override void Load()
	{
		SetId(90172);
		SetName("Suspicious Movement (3)");
		SetDescription("Talk to the Linker Master");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_20"));
		AddPrerequisite(new LevelPrerequisite(290));

		AddObjective("collect0", "Collect 3 Gazing Golem Fragment(s)", new CollectItemObjective("LOWLV_EYEOFBAIGA_SQ_30_ITEM", 3));
		AddDrop("LOWLV_EYEOFBAIGA_SQ_30_ITEM", 10f, "Gazing_Golem_yellow_Q1");

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LOWLV_EYEOFBAIGA_SQ_30_ST", "LOWLV_EYEOFBAIGA_SQ_30", "What should I do?", "Not interested."))
			{
				case 1:
					await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_30_AG");
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
			if (character.Inventory.HasItem("LOWLV_EYEOFBAIGA_SQ_30_ITEM", 3))
			{
				character.Inventory.RemoveItem("LOWLV_EYEOFBAIGA_SQ_30_ITEM", 3);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_30_SU");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

