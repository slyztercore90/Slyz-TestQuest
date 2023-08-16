//--- Melia Script -----------------------------------------------------------
// Back in time(7)
//--- Description -----------------------------------------------------------
// Quest to Check the Kaleidoscope of Time.
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

[QuestScript(60206)]
public class Quest60206Script : QuestScript
{
	protected override void Load()
	{
		SetId(60206);
		SetName("Back in time(7)");
		SetDescription("Check the Kaleidoscope of Time");
		SetTrack("SProgress", "ESuccess", "FIRETOWER691_MQ_5_TRACK", "boss_a");

		AddPrerequisite(new CompletedPrerequisite("FIRETOWER691_MQ_4"));
		AddPrerequisite(new LevelPrerequisite(308));

		AddObjective("kill0", "Kill 1 Turtai", new KillObjective(58525, 1));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 14168));

		AddDialogHook("MASTER_CHRONO", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("FIRETOWER691_MQ_5_3");
			dialog.ShowHelp("TUTO_PAST_FANTASYLIBRARY");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

