//--- Melia Script -----------------------------------------------------------
// [Jaguar] Expert Hunter
//--- Description -----------------------------------------------------------
// Quest to Talk to the Jaguar Master at the Khamadon Forest.
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

[QuestScript(550011)]
public class Quest550011Script : QuestScript
{
	protected override void Load()
	{
		SetId(550011);
		SetName("[Jaguar] Expert Hunter");
		SetDescription("Talk to the Jaguar Master at the Khamadon Forest");

		AddPrerequisite(new LevelPrerequisite(1));

		AddDialogHook("MASTER_JAGUAR_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_JAGUAR_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UQ_Char5_18_PRE1_DLG1", "UQ_Char5_18_PRE1", "I will prove myself.", "I'm not interested at the moment."))
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
		await dialog.Msg("UQ_Char5_18_PRE1_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

