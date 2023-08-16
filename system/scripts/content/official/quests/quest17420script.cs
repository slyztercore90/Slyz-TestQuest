//--- Melia Script -----------------------------------------------------------
// Statue Maintenance [Dievdirbys Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Meet with Sculptor Tesla.
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

[QuestScript(17420)]
public class Quest17420Script : QuestScript
{
	protected override void Load()
	{
		SetId(17420);
		SetName("Statue Maintenance [Dievdirbys Advancement] (1)");
		SetDescription("Meet with Sculptor Tesla");

		AddPrerequisite(new LevelPrerequisite(135));

		AddReward(new ItemReward("JOB_DIEVDIRBYS4_1_ITEM", 1));

		AddDialogHook("JOB_DIEVDIRBYS2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_DIEVDIRBYS4_1_ST", "JOB_DIEVDIRBYS4_1", "I will try", "I won't need it"))
			{
				case 1:
					await dialog.Msg("JOB_DIEVDIRBYS4_1_AC");
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_DIEVDIRBYS4_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_DIEVDIRBYS4_2");
	}
}

