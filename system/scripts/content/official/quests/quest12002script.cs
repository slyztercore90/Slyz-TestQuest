//--- Melia Script -----------------------------------------------------------
// Going Down the Right Path [Peltasta Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Peltasta Master.
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

[QuestScript(12002)]
public class Quest12002Script : QuestScript
{
	protected override void Load()
	{
		SetId(12002);
		SetName("Going Down the Right Path [Peltasta Advancement]");
		SetDescription("Talk to the Peltasta Master");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("kill0", "Kill 25 Jukopus(s)", new KillObjective(400061, 25));

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA1_select1", "JOB_PELTASTA1", "I will carry out the assignment", "Cancel"))
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
			await dialog.Msg("JOB_PELTASTA1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

