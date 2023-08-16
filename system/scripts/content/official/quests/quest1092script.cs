//--- Melia Script -----------------------------------------------------------
// Dream Book of the Bow 3 [Archer Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Master.
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

[QuestScript(1092)]
public class Quest1092Script : QuestScript
{
	protected override void Load()
	{
		SetId(1092);
		SetName("Dream Book of the Bow 3 [Archer Advancement] (2)");
		SetDescription("Talk to the Archer Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_ARCHER2_1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddReward(new ItemReward("Book2", 1));

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_HUNTER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ARCHER2_2_select1", "JOB_ARCHER2_2", "I'll pay for the book", "I need time to prepare money for the book"))
			{
				case 1:
					await dialog.Msg("JOB_ARCHER2_2_agree1");
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
			if (character.Inventory.HasItem("Vis", 1000))
			{
				character.Inventory.RemoveItem("Vis", 1000);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("EffectLocalNPC/JOB_HUNTER2_1_NPC/archer_buff_skl_Recuperate_circle/1.5/BOT");
				await dialog.Msg("JOB_ARCHER2_2_succ1");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

