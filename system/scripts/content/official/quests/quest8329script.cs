//--- Melia Script -----------------------------------------------------------
// Sculptor's Trial (1)
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

[QuestScript(8329)]
public class Quest8329Script : QuestScript
{
	protected override void Load()
	{
		SetId(8329);
		SetName("Sculptor's Trial (1)");
		SetDescription("Talk to the Owl Sculpture of Forecasts");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_22"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 10 Black Zigri(s) or Red Puragi(s)", new KillObjective(10, 400323, 400304));

		AddDialogHook("KATYN18_MAIN_OWL", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_MAIN_OWL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_23_01", "KATYN18_MQ_23", "Suggest that you will defeat monsters.", "Cancel"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("KATYN18_MQ_23_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_24");
	}
}

