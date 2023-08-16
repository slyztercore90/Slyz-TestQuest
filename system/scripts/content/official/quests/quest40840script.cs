//--- Melia Script -----------------------------------------------------------
// For the Guidance of Souls
//--- Description -----------------------------------------------------------
// Quest to Return to Kupole Meile.
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

[QuestScript(40840)]
public class Quest40840Script : QuestScript
{
	protected override void Load()
	{
		SetId(40840);
		SetName("For the Guidance of Souls");
		SetDescription("Return to Kupole Meile");

		AddPrerequisite(new CompletedPrerequisite("FLASH_29_1_SQ_060"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddReward(new ExpReward(237943, 237943));
		AddReward(new ItemReward("expCard10", 3));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH_29_1_KUPOLE_MEILE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH_29_1_SQ_070_ST", "FLASH_29_1_SQ_070", "Ask her to guide the spirits", "Listen closely"))
			{
				case 1:
					await dialog.Msg("FLASH_29_1_SQ_070_AC");
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

