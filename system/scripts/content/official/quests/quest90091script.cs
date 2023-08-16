//--- Melia Script -----------------------------------------------------------
// Nobody Expects the Inquisition (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Priest Master at Klaipeda.
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

[QuestScript(90091)]
public class Quest90091Script : QuestScript
{
	protected override void Load()
	{
		SetId(90091);
		SetName("Nobody Expects the Inquisition (1)");
		SetDescription("Talk with the Priest Master at Klaipeda");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_25_4_SQ_80"));
		AddPrerequisite(new LevelPrerequisite(292));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_25_4_LAIMIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CATACOMB_25_4_SQ_90_SU");
			dialog.HideNPC("CATACOMB_25_4_SQ_KOSTAS");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

