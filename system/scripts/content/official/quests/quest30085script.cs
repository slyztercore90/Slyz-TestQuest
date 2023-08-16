//--- Melia Script -----------------------------------------------------------
// Natural Enemy [Archer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Submaster.
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

[QuestScript(30085)]
public class Quest30085Script : QuestScript
{
	protected override void Load()
	{
		SetId(30085);
		SetName("Natural Enemy [Archer Advancement]");
		SetDescription("Talk to the Archer Submaster");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_ARCHER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_ARCHER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_ARCHER_3_1_select", "JOB_2_ARCHER_3_1", "I'll be back in a second", "Test me again"))
			{
				case 1:
					await dialog.Msg("JOB_2_ARCHER_3_1_agree");
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
			await dialog.Msg("JOB_2_ARCHER_3_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

