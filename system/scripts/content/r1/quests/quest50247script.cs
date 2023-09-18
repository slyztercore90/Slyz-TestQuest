//--- Melia Script -----------------------------------------------------------
// How to Charm [Taoist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with the Taoist Master.
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

[QuestScript(50247)]
public class Quest50247Script : QuestScript
{
	protected override void Load()
	{
		SetId(50247);
		SetName("How to Charm [Taoist Advancement]");
		SetDescription("Talk with the Taoist Master");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("DAOSHI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("DAOSHI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_DAOSHI_8_1_START1", "JOB_DAOSHI_8_1", "No problem", "Give me a moment to think about that"))
		{
			case 1:
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

		await dialog.Msg("JOB_DAOSHI_8_1_SUCC1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

