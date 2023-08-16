//--- Melia Script -----------------------------------------------------------
// Seal of the Royal Family (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Ahylas Jonas.
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

[QuestScript(7017)]
public class Quest7017Script : QuestScript
{
	protected override void Load()
	{
		SetId(7017);
		SetName("Seal of the Royal Family (1)");
		SetDescription("Talk to Ahylas Jonas");

		AddPrerequisite(new CompletedPrerequisite("ROKAS24_MQ_2"));
		AddPrerequisite(new LevelPrerequisite(61));

		AddDialogHook("ROKAS24_ALCHEMIST", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS25_REXIPHER3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS25_REXIPHER1_select1", "ROKAS25_REXIPHER1", "I'll go to Ramstis Ridge and release the seals", "I'll quit here"))
			{
				case 1:
					await dialog.Msg("ROKAS25_REXIPHER1_AC");
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
			await dialog.Msg("ROKAS25_REXIPHER1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

