//--- Melia Script -----------------------------------------------------------
// A Sword and Shield for the People (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Highlander Master.
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

[QuestScript(72140)]
public class Quest72140Script : QuestScript
{
	protected override void Load()
	{
		SetId(72140);
		SetName("A Sword and Shield for the People (1)");
		SetDescription("Find the Highlander Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_HIGHLANDER1_2"));
		AddPrerequisite(new LevelPrerequisite(135));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_HIGHLANDER2_1_DLG1", "MASTER_HIGHLANDER2_1", "I'll help the Peltasta Master", "Decline"))
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
			await dialog.Msg("JOB_HIGHLANDER4_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_HIGHLANDER2_2");
	}
}

