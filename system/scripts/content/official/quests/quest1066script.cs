//--- Melia Script -----------------------------------------------------------
// In their Honor (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Stonemason Pipoti.
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

[QuestScript(1066)]
public class Quest1066Script : QuestScript
{
	protected override void Load()
	{
		SetId(1066);
		SetName("In their Honor (3)");
		SetDescription("Talk to Stonemason Pipoti");

		AddPrerequisite(new CompletedPrerequisite("ROKAS29_VACYS8"));
		AddPrerequisite(new LevelPrerequisite(96));

		AddDialogHook("ROKAS24_PIPOTI", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS31_RECORD", "BeforeEnd", BeforeEnd);
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
			dialog.UnHideNPC("ROKAS31_RECORD");
			await dialog.Msg("CustomOkDlg/ROKAS31_RECORD_basic1/ROKAS29_VACYS9_SUCC_DIALOG_FUNC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

