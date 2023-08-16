//--- Melia Script -----------------------------------------------------------
// Statue Maintenance [Dievdirbys Advancement] (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cleric Master.
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

[QuestScript(17430)]
public class Quest17430Script : QuestScript
{
	protected override void Load()
	{
		SetId(17430);
		SetName("Statue Maintenance [Dievdirbys Advancement] (2)");
		SetDescription("Talk to the Cleric Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_DIEVDIRBYS4_1"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddReward(new ItemReward("JOB_DIEVDIRBYS4_1_ITEM", 1));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_DIEVDIRBYS4_2_ST", "JOB_DIEVDIRBYS4_2", "I'll go to the Krivis Master", "Quit"))
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
			await dialog.Msg("JOB_DIEVDIRBYS4_2_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_DIEVDIRBYS4_3");
	}
}

