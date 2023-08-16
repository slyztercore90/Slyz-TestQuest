//--- Melia Script -----------------------------------------------------------
// Remembering the Victims (2)
//--- Description -----------------------------------------------------------
// Quest to Carve a Message to Honor the Victims.
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

[QuestScript(50277)]
public class Quest50277Script : QuestScript
{
	protected override void Load()
	{
		SetId(50277);
		SetName("Remembering the Victims (2)");
		SetDescription("Carve a Message to Honor the Victims");

		AddPrerequisite(new CompletedPrerequisite("ABBEY64_2_HQ1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("ABBEY64_2_HIDDENQ2_OBJ1", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_TOWN_PEAPLE2", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("ABBEY64_2_HQ2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

