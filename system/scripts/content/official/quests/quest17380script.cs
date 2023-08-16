//--- Melia Script -----------------------------------------------------------
// Still Needs Memory [Bokor Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Meet the Bokor Master.
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

[QuestScript(17380)]
public class Quest17380Script : QuestScript
{
	protected override void Load()
	{
		SetId(17380);
		SetName("Still Needs Memory [Bokor Advancement] (1)");
		SetDescription("Meet the Bokor Master");

		AddPrerequisite(new LevelPrerequisite(135));

		AddReward(new ItemReward("JOB_BOCOR4_1_ITEM", 1));

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_BOCOR4_1_ST", "JOB_BOCOR4_1", "I will get the gem", "Decline"))
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
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("JOB_BOCOR4_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_BOCOR4_2");
	}
}

