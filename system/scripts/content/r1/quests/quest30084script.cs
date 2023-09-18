//--- Melia Script -----------------------------------------------------------
// The Link [Linker Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(30084)]
public class Quest30084Script : QuestScript
{
	protected override void Load()
	{
		SetId(30084);
		SetName("The Link [Linker Advancement]");
		SetDescription("Talk to the Linker Master");

		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_LINKER_3_1_select", "JOB_2_LINKER_3_1", "I'll try to do it", "I hate difficult things"))
		{
			case 1:
				await dialog.Msg("JOB_2_LINKER_3_1_agree");
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

		await dialog.Msg("JOB_2_LINKER_3_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

