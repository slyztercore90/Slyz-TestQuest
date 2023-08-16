//--- Melia Script -----------------------------------------------------------
// The Eye of Demon Lord (2)
//--- Description -----------------------------------------------------------
// Quest to Check the Demon Sent by Gazing Golem.
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

[QuestScript(90176)]
public class Quest90176Script : QuestScript
{
	protected override void Load()
	{
		SetId(90176);
		SetName("The Eye of Demon Lord (2)");
		SetDescription("Check the Demon Sent by Gazing Golem");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_60"));
		AddPrerequisite(new LevelPrerequisite(290));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_70_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

