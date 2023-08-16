//--- Melia Script -----------------------------------------------------------
// Disturbance of the Winged Beast [Peltasta Advancement] (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Fletcher Master.
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

[QuestScript(8708)]
public class Quest8708Script : QuestScript
{
	protected override void Load()
	{
		SetId(8708);
		SetName("Disturbance of the Winged Beast [Peltasta Advancement] (4)");
		SetDescription("Talk to the Fletcher Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_PELTASTA4_3"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA4_4_01", "JOB_PELTASTA4_4", "I'll go back to the Peltasta Master", "I'll wait a little bit"))
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
			await dialog.Msg("JOB_PELTASTA4_4_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

