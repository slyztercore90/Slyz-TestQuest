//--- Melia Script -----------------------------------------------------------
// Repair the Practice Wooden Seal (2)
//--- Description -----------------------------------------------------------
// Quest to Repair the wooden seal for practice.
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

[QuestScript(9111)]
public class Quest9111Script : QuestScript
{
	protected override void Load()
	{
		SetId(9111);
		SetName("Repair the Practice Wooden Seal (2)");
		SetDescription("Repair the wooden seal for practice");

		AddPrerequisite(new CompletedPrerequisite("HIGHLANDER_HQ_01"));
		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("HIGHLANDER_HQ_02_succ01");
			// Func/HIGHLANDER_HQ02_COMP;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

