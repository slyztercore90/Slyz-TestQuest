//--- Melia Script -----------------------------------------------------------
// Try Fishing
//--- Description -----------------------------------------------------------
// Quest to Talk to Fishing Manager Joha in Klaipeda..
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

[QuestScript(1162)]
public class Quest1162Script : QuestScript
{
	protected override void Load()
	{
		SetId(1162);
		SetName("Try Fishing");
		SetDescription("Talk to Fishing Manager Joha in Klaipeda.");

		AddPrerequisite(new LevelPrerequisite(30));

		AddDialogHook("KLAPEDA_FISHING_MANAGER", "BeforeStart", BeforeStart);
		AddDialogHook("KLAPEDA_FISHING_MANAGER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("TUTO_FISHING_SUCCESS_DLG1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

