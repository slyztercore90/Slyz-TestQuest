//--- Melia Script -----------------------------------------------------------
// Sword for the People and Shield [Highlander Advancement](1)
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

[QuestScript(8701)]
public class Quest8701Script : QuestScript
{
	protected override void Load()
	{
		SetId(8701);
		SetName("Sword for the People and Shield [Highlander Advancement](1)");
		SetDescription("Find the Highlander Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_HIGHLANDER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_HIGHLANDER4_1_01", "JOB_HIGHLANDER4_1", "I'll help the Peltasta Master", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_HIGHLANDER4_1_AG");
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
		character.Quests.Start("JOB_HIGHLANDER4_2");
	}
}

