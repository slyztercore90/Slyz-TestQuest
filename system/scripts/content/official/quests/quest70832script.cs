//--- Melia Script -----------------------------------------------------------
// As the Revelator proposed
//--- Description -----------------------------------------------------------
// Quest to Talk to Lord Ryudhas.
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

[QuestScript(70832)]
public class Quest70832Script : QuestScript
{
	protected override void Load()
	{
		SetId(70832);
		SetName("As the Revelator proposed");
		SetDescription("Talk to Lord Ryudhas");

		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ12"));
		AddPrerequisite(new LevelPrerequisite(319));

		AddDialogHook("MAPLE232_SQ_13_1", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_13_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE232_SQ_13_start", "MAPLE23_2_SQ13", "Propose that a new boundary should be set with Lord Joquvas", "Think of another solution"))
			{
				case 1:
					await dialog.Msg("MAPLE232_SQ_13_agree");
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
			await dialog.Msg("MAPLE232_SQ_13_succ1");
			dialog.UnHideNPC("MAPLE232_SQ_13_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

