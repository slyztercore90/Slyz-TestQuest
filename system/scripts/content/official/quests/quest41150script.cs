//--- Melia Script -----------------------------------------------------------
// Final Conclusion (5)
//--- Description -----------------------------------------------------------
// Quest to Go to Liugas Access Road and save Fabijus.
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

[QuestScript(41150)]
public class Quest41150Script : QuestScript
{
	protected override void Load()
	{
		SetId(41150);
		SetName("Final Conclusion (5)");
		SetDescription("Go to Liugas Access Road and save Fabijus");
		SetTrack("SProgress", "ESuccess", "PILGRIM_36_2_SQ_150_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM_36_2_SQ_140"));
		AddPrerequisite(new LevelPrerequisite(106));

		AddObjective("kill0", "Kill 1 Fire Lord", new KillObjective(57805, 1));

		AddReward(new ExpReward(294852, 294852));
		AddReward(new ItemReward("expCard6", 6));
		AddReward(new ItemReward("Vis", 2544));

		AddDialogHook("PILGRIM_36_2_SQ_150_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM_36_2_GEDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("PILGRIM_36_2_SQ_150_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

