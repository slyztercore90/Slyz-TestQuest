//--- Melia Script -----------------------------------------------------------
// Reading the Clue
//--- Description -----------------------------------------------------------
// Quest to Find the person who has a clue .
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

[QuestScript(40315)]
public class Quest40315Script : QuestScript
{
	protected override void Load()
	{
		SetId(40315);
		SetName("Reading the Clue");
		SetDescription("Find the person who has a clue ");

		AddPrerequisite(new CompletedPrerequisite("FARM47_2_SQ_010"), new CompletedPrerequisite("FARM47_2_SQ_020"), new CompletedPrerequisite("FARM47_2_SQ_030"), new CompletedPrerequisite("FARM47_2_SQ_040"));
		AddPrerequisite(new LevelPrerequisite(89));

		AddDialogHook("FARM47_JOANA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_JOANA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_2_SQ_045_ST", "FARM47_2_SQ_045", "Show the fragments", "Leave as this seems suspicious"))
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
			await dialog.Msg("FARM47_2_SQ_045_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FARM47_2_SQ_050");
	}
}

