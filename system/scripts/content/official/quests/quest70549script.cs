//--- Melia Script -----------------------------------------------------------
// Resolving conflicts
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Dorma.
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

[QuestScript(70549)]
public class Quest70549Script : QuestScript
{
	protected override void Load()
	{
		SetId(70549);
		SetName("Resolving conflicts");
		SetDescription("Talk to Monk Dorma");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ02"));
		AddPrerequisite(new LevelPrerequisite(265));

		AddDialogHook("PILGRIM414_SQ_02_1", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM414_SQ_10_start", "PILGRIM41_4_SQ10"))
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
			await dialog.Msg("PILGRIM414_SQ_10_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

