//--- Melia Script -----------------------------------------------------------
// Depressed Spirit (2)
//--- Description -----------------------------------------------------------
// Quest to Absorb the resentment into the Orb of Comfort.
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

[QuestScript(50037)]
public class Quest50037Script : QuestScript
{
	protected override void Load()
	{
		SetId(50037);
		SetName("Depressed Spirit (2)");
		SetDescription("Absorb the resentment into the Orb of Comfort");

		AddPrerequisite(new CompletedPrerequisite("PARTY_Q_050"));
		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("PARTY_Q_052_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

