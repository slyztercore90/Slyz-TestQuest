//--- Melia Script -----------------------------------------------------------
// Effect Too Strong (2)
//--- Description -----------------------------------------------------------
// Quest to Go to Centaurus.
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

[QuestScript(70728)]
public class Quest70728Script : QuestScript
{
	protected override void Load()
	{
		SetId(70728);
		SetName("Effect Too Strong (2)");
		SetDescription("Go to Centaurus");
		SetTrack("SPossible", "ESuccess", "BRACKEN42_2_SQ09_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN42_2_SQ08"));
		AddPrerequisite(new LevelPrerequisite(282));

		AddDialogHook("BRACKEN422_SQ_09", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN422_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("HideNPC/BRACKEN422_SQ_08/0/0", "BRACKEN42_2_SQ09"))
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
			await dialog.Msg("BRACKEN422_SQ_09_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

