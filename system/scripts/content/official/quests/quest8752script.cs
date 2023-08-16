//--- Melia Script -----------------------------------------------------------
// Astral Tracing (6)
//--- Description -----------------------------------------------------------
// Quest to Check the last gravestone.
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

[QuestScript(8752)]
public class Quest8752Script : QuestScript
{
	protected override void Load()
	{
		SetId(8752);
		SetName("Astral Tracing (6)");
		SetDescription("Check the last gravestone");

		AddPrerequisite(new CompletedPrerequisite("REMAIN38_MQ05"));
		AddPrerequisite(new LevelPrerequisite(99));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_MQ_MONUMENT5", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_MQ_MONUMENT5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("REMAIN38_MQ06_03");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You are enlightened after checking what was written on the tombstones of Lydia Schaffen{nl}You have acquired 1 Status Point!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

