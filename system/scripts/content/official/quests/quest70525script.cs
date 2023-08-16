//--- Melia Script -----------------------------------------------------------
// Mounting Suspicions
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Clark.
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

[QuestScript(70525)]
public class Quest70525Script : QuestScript
{
	protected override void Load()
	{
		SetId(70525);
		SetName("Mounting Suspicions");
		SetDescription("Talk to Believer Clark");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_2_SQ05"));
		AddPrerequisite(new LevelPrerequisite(261));

		AddDialogHook("PILGRIM412_SQ_05", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM412_SQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM412_SQ_06_start", "PILGRIM41_2_SQ06"))
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
			await dialog.Msg("PILGRIM412_SQ_06_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

