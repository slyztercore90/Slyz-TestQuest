//--- Melia Script -----------------------------------------------------------
// Vocation of Treatment [Cleric Advancement]
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

[QuestScript(1137)]
public class Quest1137Script : QuestScript
{
	protected override void Load()
	{
		SetId(1137);
		SetName("Vocation of Treatment [Cleric Advancement]");
		SetDescription("Talk to the Cleric Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_CLERIC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_CLERIC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_CLERIC3_1_select1", "JOB_CLERIC3_1", "I will treat the people", "Decline"))
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
			await dialog.Msg("JOB_CLERIC3_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

