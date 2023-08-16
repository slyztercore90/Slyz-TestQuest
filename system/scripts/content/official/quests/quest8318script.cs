//--- Melia Script -----------------------------------------------------------
// Demon soaked in the Woods (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Sacred Owl Sculpture.
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

[QuestScript(8318)]
public class Quest8318Script : QuestScript
{
	protected override void Load()
	{
		SetId(8318);
		SetName("Demon soaked in the Woods (2)");
		SetDescription("Talk with the Sacred Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_11"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KATYN18_OWL_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_12_01", "KATYN18_MQ_12", "We propose that the visit the owl image", "Cancel"))
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
			await dialog.Msg("KATYN18_MQ_12_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_13");
	}
}

