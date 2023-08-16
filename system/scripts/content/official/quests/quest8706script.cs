//--- Melia Script -----------------------------------------------------------
// Disturbance of the Winged Beast [Peltasta Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Highlander Master.
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

[QuestScript(8706)]
public class Quest8706Script : QuestScript
{
	protected override void Load()
	{
		SetId(8706);
		SetName("Disturbance of the Winged Beast [Peltasta Advancement] (2)");
		SetDescription("Talk to the Highlander Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_PELTASTA4_1"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA4_2_01", "JOB_PELTASTA4_2", "I'll go find the Fletcher Master", "Decline"))
			{
				case 1:
					// Func/JOB_PELTASTA4_2_TRACK_RUN;
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
			await dialog.Msg("JOB_PELTASTA4_2_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_PELTASTA4_3");
	}
}

