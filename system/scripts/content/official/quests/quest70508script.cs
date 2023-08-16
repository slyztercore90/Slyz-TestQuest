//--- Melia Script -----------------------------------------------------------
// Those that leave and those that stay
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Jacob.
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

[QuestScript(70508)]
public class Quest70508Script : QuestScript
{
	protected override void Load()
	{
		SetId(70508);
		SetName("Those that leave and those that stay");
		SetDescription("Talk to Pilgrim Jacob");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_1_SQ07"), new CompletedPrerequisite("PILGRIM41_1_SQ08"));
		AddPrerequisite(new LevelPrerequisite(258));

		AddDialogHook("PILGRIM411_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM411_SQ_09_start", "PILGRIM41_1_SQ09"))
			{
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
			await dialog.Msg("PILGRIM411_SQ_09_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

