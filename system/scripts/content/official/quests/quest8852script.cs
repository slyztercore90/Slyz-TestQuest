//--- Melia Script -----------------------------------------------------------
// Value of the Alchemist
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Saliamonas.
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

[QuestScript(8852)]
public class Quest8852Script : QuestScript
{
	protected override void Load()
	{
		SetId(8852);
		SetName("Value of the Alchemist");
		SetDescription("Talk with Alchemist Saliamonas");

		AddPrerequisite(new LevelPrerequisite(196));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_SALIAMONS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_SALIAMONS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH64_SQ_08_01", "FLASH64_SQ_08", "I'll help you", "About the curse of petrification", "I'm busy"))
			{
				case 1:
					await dialog.Msg("FLASH64_SQ_08_01_01");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("FLASH64_SQ_08_01_add");
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
			await dialog.Msg("FLASH64_SQ_08_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

