//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Retia.
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

[QuestScript(40815)]
public class Quest40815Script : QuestScript
{
	protected override void Load()
	{
		SetId(40815);
		SetName("Check the Detector's Functionality (4)");
		SetDescription("Talk to Royal Army Guard Retia");

		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_040"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddDialogHook("FLASH59_RETIA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH_29_1_SQ_045_ST", "FLASH_29_1_SQ_045", "Send the words of appreciation", "I will stay here for a while"))
			{
				case 1:
					await dialog.Msg("FLASH_29_1_SQ_045_AC");
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
			await dialog.Msg("FLASH_29_1_SQ_045_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FLASH_29_1_SQ_050");
	}
}

