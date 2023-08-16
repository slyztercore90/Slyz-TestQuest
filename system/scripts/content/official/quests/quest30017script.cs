//--- Melia Script -----------------------------------------------------------
// Passing Words (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the wandering spirit.
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

[QuestScript(30017)]
public class Quest30017Script : QuestScript
{
	protected override void Load()
	{
		SetId(30017);
		SetName("Passing Words (1)");
		SetDescription("Talk to the wandering spirit");

		AddPrerequisite(new LevelPrerequisite(194));

		AddDialogHook("CATACOMB_38_1_NPC_01", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_38_1_NPC_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_38_1_SQ_01_select", "CATACOMB_38_1_SQ_01"))
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
			await dialog.Msg("CATACOMB_38_1_SQ_01_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_38_1_SQ_02");
	}
}

