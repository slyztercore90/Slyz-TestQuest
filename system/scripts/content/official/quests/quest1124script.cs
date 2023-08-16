//--- Melia Script -----------------------------------------------------------
// Investigator of Fedimian [Ranger Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Ranger Master.
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

[QuestScript(1124)]
public class Quest1124Script : QuestScript
{
	protected override void Load()
	{
		SetId(1124);
		SetName("Investigator of Fedimian [Ranger Advancement] (1)");
		SetDescription("Talk to the Ranger Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WARLOCK3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_RANGER3_1_select1", "JOB_RANGER3_1", "Tell me about it", "Cancel"))
			{
				case 1:
					await dialog.Msg("JOB_RANGER3_1_AG");
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
			await dialog.Msg("JOB_RANGER3_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_RANGER3_2");
	}
}

