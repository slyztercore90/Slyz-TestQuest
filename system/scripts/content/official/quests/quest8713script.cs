//--- Melia Script -----------------------------------------------------------
// The First Arrow [Archer Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Fletcher Master.
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

[QuestScript(8713)]
public class Quest8713Script : QuestScript
{
	protected override void Load()
	{
		SetId(8713);
		SetName("The First Arrow [Archer Advancement] (3)");
		SetDescription("Talk to the Fletcher Master");

		AddPrerequisite(new CompletedPrerequisite("JOB_ARCHER4_2"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ARCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ARCHER4_3_01", "JOB_ARCHER4_3", "I'll return to the Archer Master", "I'll go in a while"))
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
			await dialog.Msg("JOB_ARCHER4_3_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

