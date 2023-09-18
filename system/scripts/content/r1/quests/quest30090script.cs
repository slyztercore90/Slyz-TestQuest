//--- Melia Script -----------------------------------------------------------
// Tiral by Fire [Pyromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Submaster.
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

[QuestScript(30090)]
public class Quest30090Script : QuestScript
{
	protected override void Load()
	{
		SetId(30090);
		SetName("Tiral by Fire [Pyromancer Advancement]");
		SetDescription("Talk to the Pyromancer Submaster");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_2_PYROMANCER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_PYROMANCER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_PYROMANCER_4_1_select", "JOB_2_PYROMANCER_4_1", "I will take the trial by fire.", "Decline"))
		{
			case 1:
				await dialog.Msg("JOB_2_PYROMANCER_4_1_agree");
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

		await dialog.Msg("JOB_2_PYROMANCER_4_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

