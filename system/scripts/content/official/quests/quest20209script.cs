//--- Melia Script -----------------------------------------------------------
// Astral Tracing (2)
//--- Description -----------------------------------------------------------
// Quest to The Second Rubbing.
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

[QuestScript(20209)]
public class Quest20209Script : QuestScript
{
	protected override void Load()
	{
		SetId(20209);
		SetName("Astral Tracing (2)");
		SetDescription("The Second Rubbing");

		AddPrerequisite(new CompletedPrerequisite("REMAIN38_MQ01"));
		AddPrerequisite(new LevelPrerequisite(99));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 1980));

		AddDialogHook("REMAIN38_MQ_MONUMENT2", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN38_HUNTER", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("REMAIN38_MQ02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

