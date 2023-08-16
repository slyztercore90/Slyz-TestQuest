//--- Melia Script -----------------------------------------------------------
// Magical Opinion (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bokor Edita.
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

[QuestScript(8850)]
public class Quest8850Script : QuestScript
{
	protected override void Load()
	{
		SetId(8850);
		SetName("Magical Opinion (2)");
		SetDescription("Talk to Bokor Edita");

		AddPrerequisite(new CompletedPrerequisite("FLASH64_SQ_05"));
		AddPrerequisite(new LevelPrerequisite(196));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 6076));

		AddDialogHook("FLASH64_EDITA", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH64_EDITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH64_SQ_06_01", "FLASH64_SQ_06", "I'll go there", "Reject"))
			{
				case 1:
					await dialog.Msg("FLASH64_SQ_06_02");
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
			await dialog.Msg("FLASH64_SQ_06_03");
			dialog.HideNPC("FLASH64_SQ_06_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

