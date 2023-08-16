//--- Melia Script -----------------------------------------------------------
// Still Needs Memory [Bokor Advancement] (3)
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

[QuestScript(17400)]
public class Quest17400Script : QuestScript
{
	protected override void Load()
	{
		SetId(17400);
		SetName("Still Needs Memory [Bokor Advancement] (3)");
		SetDescription("Meet the Bokor Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_BOCOR4_2"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("MASTER_BOCORS", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_BOCOR4_3_ST", "JOB_BOCOR4_3", "I will deliver it to the Krivis Master", "I will stop now, I'm too afraid"))
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
			await dialog.Msg("JOB_BOCOR4_3_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_BOCOR4_4");
	}
}

