//--- Melia Script -----------------------------------------------------------
// Wandering Spirit (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Owl Sculpture of Forecasts.
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

[QuestScript(8328)]
public class Quest8328Script : QuestScript
{
	protected override void Load()
	{
		SetId(8328);
		SetName("Wandering Spirit (4)");
		SetDescription("Talk to the Owl Sculpture of Forecasts");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KATYN18_MAIN_OWL", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_MAIN_OWL", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("KATYN18_MQ_22_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_23");
	}
}

