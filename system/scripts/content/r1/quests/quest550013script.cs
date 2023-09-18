//--- Melia Script -----------------------------------------------------------
// [Shenji] God of Spear
//--- Description -----------------------------------------------------------
// Quest to Talk to Shenji Master Dana.
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

[QuestScript(550013)]
public class Quest550013Script : QuestScript
{
	protected override void Load()
	{
		SetId(550013);
		SetName("[Shenji] God of Spear");
		SetDescription("Talk to Shenji Master Dana");

		AddPrerequisite(new LevelPrerequisite(490));

		AddDialogHook("MASTER_SPE_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_SPE_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char1_24_PRE1_DLG1", "UQ_Char1_24_PRE1", "I will prove myself.", "I have more urgent issues to tend to"))
		{
			case 1:
				// Func/SCR_SET_UNLOCK_AOBJ_UNLOCK;
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

		// Func/SCR_SET_UNLOCK_AOBJ_LOCK;
		await dialog.Msg("UQ_Char1_24_PRE1_DLG2");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

