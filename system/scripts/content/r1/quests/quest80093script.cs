//--- Melia Script -----------------------------------------------------------
// The Corrupted Spirit of the Demons (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elgos Abbot.
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

[QuestScript(80093)]
public class Quest80093Script : QuestScript
{
	protected override void Load()
	{
		SetId(80093);
		SetName("The Corrupted Spirit of the Demons (2)");
		SetDescription("Talk to the Elgos Abbot");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_4"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_ELDER", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_5_start", "ABBEY_35_4_SQ_5", "I'll go there", "It's too far away"))
		{
			case 1:
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

		if (character.Inventory.HasItem("Drug_holywater", 10))
		{
			character.Inventory.RemoveItem("Drug_holywater", 10);
			await dialog.Msg("ABBEY_35_4_SQ_5_succ");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("NPCAin/ABBEY_35_4_ELDER/event_idle2/0");
			character.Quests.Complete(this.QuestId);
			await Task.Delay(500);
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EffectLocalNPC/ABBEY_35_4_ELDER/spread_in011_blue/2/MID");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EffectLocalNPC/ABBEY_35_4_ELDER/F_buff_basic018_blue_fire_1/2/BOT");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EffectLocalNPC/ABBEY_35_4_ELDER/F_pc_making_finish_white/1/TOP");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

