//--- Melia Script -----------------------------------------------------------
// Guilty Conscience (3)
//--- Description -----------------------------------------------------------
// Quest to Deliver the Pouch to the Cleric Master.
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

[QuestScript(72130)]
public class Quest72130Script : QuestScript
{
	protected override void Load()
	{
		SetId(72130);
		SetName("Guilty Conscience (3)");
		SetDescription("Deliver the Pouch to the Cleric Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_SAPPER1_2"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("MASTER_SAPPER1_3_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_SAPPER1_4");
	}
}

