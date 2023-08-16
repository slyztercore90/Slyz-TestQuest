//--- Melia Script -----------------------------------------------------------
// Piece of Wing (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with the Earnest Owl Chief Sculpture.
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

[QuestScript(4820)]
public class Quest4820Script : QuestScript
{
	protected override void Load()
	{
		SetId(4820);
		SetName("Piece of Wing (1)");
		SetDescription("Talk with the Earnest Owl Chief Sculpture");

		AddPrerequisite(new CompletedPrerequisite("KATYN13_1_KEY"));
		AddPrerequisite(new LevelPrerequisite(112));

		AddDialogHook("KATYN13_1_OWLBOSS", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN13_1_OWLJUNIOR1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN13_1_Q2_11", "KATYN13_1_TO_OWLJUNIOR1", "I will deliver the Piece of Wing", "Decline"))
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
			await dialog.Msg("KATYN13_1_Q2_14");
			await dialog.Msg("EffectLocalNPC/KATYN13_1_OWLJUNIOR1/F_light018/1/MID");
			// Func/SCR_KATYN13_1_TO_OWLJUNIOR1_MON;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN13_1_TO_OWLJUNIOR2");
	}
}

