//--- Melia Script -----------------------------------------------------------
// Close Shave
//--- Description -----------------------------------------------------------
// Quest to Talk with Alchemist Sophia.
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

[QuestScript(70732)]
public class Quest70732Script : QuestScript
{
	protected override void Load()
	{
		SetId(70732);
		SetName("Close Shave");
		SetDescription("Talk with Alchemist Sophia");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ12"));
		AddPrerequisite(new LevelPrerequisite(282));

		AddDialogHook("BRACKEN422_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN422_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN422_SQ_13_start", "BRACKEN42_2_SQ13"))
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
			await dialog.Msg("BRACKEN422_SQ_13_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

