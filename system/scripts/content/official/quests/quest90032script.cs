//--- Melia Script -----------------------------------------------------------
// What Happened to the Owl Sculptures?
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sleeping Owl Sculpture.
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

[QuestScript(90032)]
public class Quest90032Script : QuestScript
{
	protected override void Load()
	{
		SetId(90032);
		SetName("What Happened to the Owl Sculptures?");
		SetDescription("Talk to the Sleeping Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_1_SQ_1"));
		AddPrerequisite(new LevelPrerequisite(245));

		AddDialogHook("KATYN_45_1_OWL1", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_1_AJEL1", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("KATYN_45_1_SQ_2_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

