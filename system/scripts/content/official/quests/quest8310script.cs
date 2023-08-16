//--- Melia Script -----------------------------------------------------------
// The Silent Forest (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Weak Owl Sculpture.
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

[QuestScript(8310)]
public class Quest8310Script : QuestScript
{
	protected override void Load()
	{
		SetId(8310);
		SetName("The Silent Forest (4)");
		SetDescription("Talk to the Weak Owl Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("KATYN18_OWL_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_LOST_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_04_01", "KATYN18_MQ_04", "To provide that the try to find the soul", "Cancel"))
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
			await dialog.Msg("KATYN18_MQ_04_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_05");
	}
}

