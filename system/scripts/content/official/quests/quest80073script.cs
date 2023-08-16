//--- Melia Script -----------------------------------------------------------
// Great Success or Great Failure (2)
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

[QuestScript(80073)]
public class Quest80073Script : QuestScript
{
	protected override void Load()
	{
		SetId(80073);
		SetName("Great Success or Great Failure (2)");
		SetDescription("Talk with Lucienne Winterspoon");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_35_1_SQ_8"));
		AddPrerequisite(new LevelPrerequisite(223));

		AddDialogHook("SIAULIAI_35_1_SQ_8_NPC_END", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI_35_1_SQ_9_END", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_35_1_SQ_9_start", "SIAULIAI_35_1_SQ_9", "Let's ask Vaidotas since it looks unstable", "I need some time to prepare"))
			{
				case 1:
					await dialog.Msg("SIAULIAI_35_1_SQ_9_agree");
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
			await dialog.Msg("BalloonText/SIAULIAI_35_1_SQ_9_MISSING/8");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_35_1_SQ_10");
	}
}

