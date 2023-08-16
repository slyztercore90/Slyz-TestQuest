//--- Melia Script -----------------------------------------------------------
// Check the Detector's Functionality (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Meile.
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

[QuestScript(40800)]
public class Quest40800Script : QuestScript
{
	protected override void Load()
	{
		SetId(40800);
		SetName("Check the Detector's Functionality (2)");
		SetDescription("Talk to Kupole Meile");

		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_020"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH59_RETIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH_29_1_SQ_030_ST", "FLASH_29_1_SQ_030", "I will go", "Look for another way"))
			{
				case 1:
					await dialog.Msg("FLASH_29_1_SQ_030_AC");
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
			await dialog.Msg("FLASH_29_1_SQ_030_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FLASH_29_1_SQ_040");
	}
}

