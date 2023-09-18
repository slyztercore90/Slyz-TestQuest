//--- Melia Script -----------------------------------------------------------
// The Best Spot [Psychokino Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Psychokino Master.
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

[QuestScript(30092)]
public class Quest30092Script : QuestScript
{
	protected override void Load()
	{
		SetId(30092);
		SetName("The Best Spot [Psychokino Advancement]");
		SetDescription("Talk to the Psychokino Master");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_2_PSYCHOKINO_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PSYCHOKINO_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PSYCHOKINO_4_1_select", "JOB_2_PSYCHOKINO_4_1", "I am ready to learn the delicate spell control.", "Cancel"))
		{
			case 1:
				await dialog.Msg("JOB_2_PSYCHOKINO_4_1_agree");
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

		await dialog.Msg("JOB_2_PSYCHOKINO_4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

