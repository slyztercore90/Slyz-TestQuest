//--- Melia Script -----------------------------------------------------------
// Revelation Guardian Zanas(3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30147)]
public class Quest30147Script : QuestScript
{
	protected override void Load()
	{
		SetId(30147);
		SetName("Revelation Guardian Zanas(3)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(259));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10360));

		AddDialogHook("PRISON_78_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_78_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON_78_MQ_3_select", "PRISON_78_MQ_3", "Say that you will get the Teal Magic Stone", "Say that you do not need such things"))
			{
				case 1:
					await dialog.Msg("PRISON_78_MQ_3_agree");
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
			if (character.Inventory.HasItem("PRISON_78_MQ_3_ITEM", 1))
			{
				character.Inventory.RemoveItem("PRISON_78_MQ_3_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("PRISON_78_MQ_3_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

