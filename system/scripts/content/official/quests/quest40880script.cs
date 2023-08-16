//--- Melia Script -----------------------------------------------------------
// His Only Desire (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Demon Svitrigaila.
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

[QuestScript(40880)]
public class Quest40880Script : QuestScript
{
	protected override void Load()
	{
		SetId(40880);
		SetName("His Only Desire (2)");
		SetDescription("Talk with Demon Svitrigaila");

		AddPrerequisite(new CompletedPrerequisite("FLASH_58_SQ_020"));
		AddPrerequisite(new LevelPrerequisite(207));

		AddDialogHook("FLASH_58_SVTRIGAILA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH_58_SQ_030_ST", "FLASH_58_SQ_030", "I will go get some holy water", "I can't cooperate with that"))
			{
				case 1:
					await dialog.Msg("FLASH_58_SQ_030_AC");
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
			await dialog.Msg("FLASH_58_SQ_030_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("FLASH_58_SQ_035");
	}
}

