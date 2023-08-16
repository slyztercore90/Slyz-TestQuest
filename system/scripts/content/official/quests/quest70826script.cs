//--- Melia Script -----------------------------------------------------------
// Convincing Lord Joquvas(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Lord Joquvas.
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

[QuestScript(70826)]
public class Quest70826Script : QuestScript
{
	protected override void Load()
	{
		SetId(70826);
		SetName("Convincing Lord Joquvas(1)");
		SetDescription("Talk to Lord Joquvas");

		AddPrerequisite(new CompletedPrerequisite("MAPLE23_2_SQ03"));
		AddPrerequisite(new LevelPrerequisite(319));

		AddDialogHook("MAPLE232_SQ_07_1", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE232_SQ_07_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE232_SQ_07_start", "MAPLE23_2_SQ07", "Ask him to hear your tale", "Step back without saying anything"))
			{
				case 1:
					// Func/SCR_MAPLE232_SQ_07_TURN;
					await dialog.Msg("MAPLE232_SQ_07_agree");
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
			await dialog.Msg("MAPLE232_SQ_07_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MAPLE23_2_SQ08");
	}
}

