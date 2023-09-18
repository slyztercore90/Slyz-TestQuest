//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 4 [Ranger Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(1096)]
public class Quest1096Script : QuestScript
{
	protected override void Load()
	{
		SetId(1096);
		SetName("Dream Book of the Bow 4 [Ranger Advancement] (2)");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(45));
		AddPrerequisite(new CompletedPrerequisite("JOB_RANGER2_1"));

		AddReward(new ItemReward("Book2", 1));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_RANGER2_2_select1", "JOB_RANGER2_2", "I'll pay for the book", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_RANGER2_2_agree1");
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

		if (character.Inventory.HasItem("Vis", 1000))
		{
			character.Inventory.RemoveItem("Vis", 1000);
			await dialog.Msg("EffectLocalNPC/JOB_HUNTER2_1_NPC/archer_buff_skl_Recuperate_circle/1.5/BOT");
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_RANGER2_2_succ1");
			character.Quests.Complete(this.QuestId);
		}

		return HookResult.Break;
	}
}

