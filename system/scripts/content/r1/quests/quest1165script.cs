//--- Melia Script -----------------------------------------------------------
// Unlock Legend Card Slot
//--- Description -----------------------------------------------------------
// Quest to Unlock the Legend Card slot with the power of the goddesses..
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

[QuestScript(1165)]
public class Quest1165Script : QuestScript
{
	protected override void Load()
	{
		SetId(1165);
		SetName("Unlock Legend Card Slot");
		SetDescription("Unlock the Legend Card slot with the power of the goddesses.");

		AddPrerequisite(new LevelPrerequisite(100));

		AddDialogHook("WARP_C_KLAIPE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		character.AddonMessage(AddonMessage.NOTICE_Dm_Clear, "The Legend Card slot was unlocked by the power of the goddesses!");
		// Func/LEGEND_CARD_LIFT_SUCC_FUNC;
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

