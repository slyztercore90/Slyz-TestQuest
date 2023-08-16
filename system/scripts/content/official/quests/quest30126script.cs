//--- Melia Script -----------------------------------------------------------
// Learn Archer Attributes
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Submaster.
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

[QuestScript(30126)]
public class Quest30126Script : QuestScript
{
	protected override void Load()
	{
		SetId(30126);
		SetName("Learn Archer Attributes");
		SetDescription("Talk to the Archer Submaster");

		AddPrerequisite(new LevelPrerequisite(3));

		AddDialogHook("JOB_2_ARCHER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_ARCHER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TUTO_2_ARCHER_TECH_select", "TUTO_2_ARCHER_TECH", "Listen to the explanation about Attributes", "Skip the explanation"))
			{
				case 1:
					dialog.ShowHelp("TUTO_TECH");
					// Func/TUTO_PIP_CLOSE_QUEST;
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
			await dialog.Msg("TUTO_2_ARCHER_TECH_succ");
			// Func/SCR_TUTO_ARCHER_SUCC;
			dialog.ShowHelp("TUTO_ABILITYPOINT_TEAM_SHARE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

