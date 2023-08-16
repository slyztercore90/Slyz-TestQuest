//--- Melia Script -----------------------------------------------------------
// The Alchemist of Nahash Forest (3)
//--- Description -----------------------------------------------------------
// Quest to Talk with Lucienne Winterspoon.
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

[QuestScript(80067)]
public class Quest80067Script : QuestScript
{
	protected override void Load()
	{
		SetId(80067);
		SetName("The Alchemist of Nahash Forest (3)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_2"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddDialogHook("SIAULIAI_35_1_LUCIEN", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_LUCIEN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_35_1_SQ_3_start", "SIAULIAI_35_1_SQ_3", "What are you doing here", "I'm not interested"))
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
			await dialog.Msg("SIAULIAI_35_1_SQ_3_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_35_1_SQ_4");
	}
}

