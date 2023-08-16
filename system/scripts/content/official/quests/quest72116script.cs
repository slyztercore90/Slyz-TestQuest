//--- Melia Script -----------------------------------------------------------
// Double Cross Trading
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Solcomm.
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

[QuestScript(72116)]
public class Quest72116Script : QuestScript
{
	protected override void Load()
	{
		SetId(72116);
		SetName("Double Cross Trading");
		SetDescription("Talk to Demon Lord Solcomm");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ01"));
		AddPrerequisite(new LevelPrerequisite(336));

		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE262_SQ02_DLG01", "F_3CMLAKE262_SQ02", "I get what you're saying. Tell me what happened next.", "I don't know."))
			{
				case 1:
					await dialog.Msg("3CMLAKE262_SQ02_DLG02");
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
			await dialog.Msg("3CMLAKE262_SQ02_DLG03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("F_3CMLAKE262_SQ03");
	}
}

