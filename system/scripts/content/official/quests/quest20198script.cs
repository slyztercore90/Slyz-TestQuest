//--- Melia Script -----------------------------------------------------------
// Self Sufficiency (2)
//--- Description -----------------------------------------------------------
// Quest to Find the first fragment of the tombstone.
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

[QuestScript(20198)]
public class Quest20198Script : QuestScript
{
	protected override void Load()
	{
		SetId(20198);
		SetName("Self Sufficiency (2)");
		SetDescription("Find the first fragment of the tombstone");

		AddPrerequisite(new CompletedPrerequisite("REMAIN37_MQ01"));
		AddPrerequisite(new LevelPrerequisite(96));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_RAYMOND", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_RAYMOND", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("REMAIN37_MQ02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

