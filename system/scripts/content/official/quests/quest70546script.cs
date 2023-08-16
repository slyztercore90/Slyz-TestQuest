//--- Melia Script -----------------------------------------------------------
// Are the demons the real culprits?
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Vados.
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

[QuestScript(70546)]
public class Quest70546Script : QuestScript
{
	protected override void Load()
	{
		SetId(70546);
		SetName("Are the demons the real culprits?");
		SetDescription("Talk to Pilgrim Vados");
		SetTrack("SPossible", "ESuccess", "PILGRIM41_4_SQ07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_4_SQ06"));
		AddPrerequisite(new LevelPrerequisite(265));

		AddDialogHook("PILGRIM414_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM414_SQ_04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM414_SQ_07_start", "PILGRIM41_4_SQ07"))
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
			await dialog.Msg("PILGRIM414_SQ_07_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

