//--- Melia Script -----------------------------------------------------------
// Solve the Problem [Highlander Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Highlander Master.
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

[QuestScript(12003)]
public class Quest12003Script : QuestScript
{
	protected override void Load()
	{
		SetId(12003);
		SetName("Solve the Problem [Highlander Advancement]");
		SetDescription("Talk to the Highlander Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("kill0", "Kill 25 Vubbe Thief(s)", new KillObjective(11120, 25));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_HIGHLANDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HIGHLANDER1_select1", "JOB_HIGHLANDER1", "I'll take the test", "I will come back later"))
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
			await dialog.Msg("JOB_HIGHLANDER1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

