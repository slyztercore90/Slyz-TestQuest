//--- Melia Script -----------------------------------------------------------
// Disturbance of the Winged Beast (4)
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

[QuestScript(72147)]
public class Quest72147Script : QuestScript
{
	protected override void Load()
	{
		SetId(72147);
		SetName("Disturbance of the Winged Beast (4)");
		SetDescription("Talk to the Fletcher Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_PELTASTA2_3"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddReward(new ItemReward("Point_Stone_100_Q", 1));

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA4_4_01", "MASTER_PELTASTA2_4", "I'll go back to the Peltasta Master", "I'll wait a little bit"))
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
			await dialog.Msg("MASTER_PELTASTA2_4_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

