//--- Melia Script -----------------------------------------------------------
// Notable Grave Robbers and Adventurers
//--- Description -----------------------------------------------------------
// Quest to Talk to Amanda.
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

[QuestScript(50269)]
public class Quest50269Script : QuestScript
{
	protected override void Load()
	{
		SetId(50269);
		SetName("Notable Grave Robbers and Adventurers");
		SetDescription("Talk to Amanda");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_69_SQ010"));
		AddPrerequisite(new LevelPrerequisite(214));

		AddDialogHook("AMANDA_69_2", "BeforeStart", BeforeStart);
		AddDialogHook("AMANDA_69_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDERFORTRESS69_HQ1_start1", "UNDERFORTRESS69_HQ1", "I'll go see the Dievdirbys Master.", "I have somewhere else to be."))
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
			await dialog.Msg("UNDERFORTRESS69_HQ1_succ1");
			await dialog.Msg("BalloonText/UNDERFORTRESS69_HQ1_AMANDA/5");
			await dialog.Msg("FadeOutIN/1000");
			await dialog.Msg("UNDERFORTRESS69_HQ1_succ2");
			// Func/UNDER69_HIDDENQ1_FUNC;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

