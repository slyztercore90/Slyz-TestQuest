//--- Melia Script -----------------------------------------------------------
// Naturally (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Lina.
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

[QuestScript(90099)]
public class Quest90099Script : QuestScript
{
	protected override void Load()
	{
		SetId(90099);
		SetName("Naturally (1)");
		SetDescription("Talk to Kupole Lina");
		SetTrack("SProgress", "ESuccess", "MAPLE_25_3_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_3_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(289));

		AddDialogHook("MAPLE_25_3_EGLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			dialog.HideNPC("MAPLE_25_3_SQ_40_3");
			dialog.HideNPC("MAPLE_25_3_SQ_40_4");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

