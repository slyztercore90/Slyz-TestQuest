//--- Melia Script -----------------------------------------------------------
// Another Soul of Zanas(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Spirit in Storage.
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

[QuestScript(30154)]
public class Quest30154Script : QuestScript
{
	protected override void Load()
	{
		SetId(30154);
		SetName("Another Soul of Zanas(1)");
		SetDescription("Talk to Zanas' Spirit in Storage");

		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_9"));
		AddPrerequisite(new LevelPrerequisite(262));

		AddObjective("collect0", "Collect 10 Core of Evil Energy(s)", new CollectItemObjective("PRISON_79_MQ_1_ITEM", 10));
		AddDrop("PRISON_79_MQ_1_ITEM", 10f, 57983, 57932, 57951);

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON_79_MQ_1_select", "PRISON_79_MQ_1", "Say that you think it's a good idea", "But that's absurd!"))
			{
				case 1:
					await dialog.Msg("PRISON_79_MQ_1_agree");
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
			if (character.Inventory.HasItem("PRISON_79_MQ_1_ITEM", 10))
			{
				character.Inventory.RemoveItem("PRISON_79_MQ_1_ITEM", 10);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PRISON_79_MQ_1_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

