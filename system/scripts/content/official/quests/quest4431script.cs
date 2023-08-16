//--- Melia Script -----------------------------------------------------------
// New Researcher's Favor (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the New Researcher in the Royal Mausoleum.
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

[QuestScript(4431)]
public class Quest4431Script : QuestScript
{
	protected override void Load()
	{
		SetId(4431);
		SetName("New Researcher's Favor (4)");
		SetDescription("Talk to the New Researcher in the Royal Mausoleum");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ROKAS_24_NEWCOMER", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_NEWCOMER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("ROKAS24_QB_4_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

