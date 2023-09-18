//--- Melia Script -----------------------------------------------------------
// Responsibility of the Olpas Painting [Monk Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Monk Master.
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

[QuestScript(30045)]
public class Quest30045Script : QuestScript
{
	protected override void Load()
	{
		SetId(30045);
		SetName("Responsibility of the Olpas Painting [Monk Advancement]");
		SetDescription("Talk to the Monk Master");

		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("JOB_MONK4_1", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_MONK4_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_MONK_6_1_select", "JOB_MONK_6_1", "I will start right away", "I need some time to prepare"))
		{
			case 1:
				await dialog.Msg("JOB_MONK_6_1_agree");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_MONK_6_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

