//--- Melia Script -----------------------------------------------------------
// Evidence of Bedazzlement (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Cordelier.
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

[QuestScript(17006)]
public class Quest17006Script : QuestScript
{
	protected override void Load()
	{
		SetId(17006);
		SetName("Evidence of Bedazzlement (3)");
		SetDescription("Talk to Cordelier");
		SetTrack("SProgress", "ESuccess", "FTOWER41_SQ_05_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("FTOWER41_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(113));

		AddObjective("kill0", "Kill 1 Ginklas", new KillObjective(57063, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("R_Hat_628063", 1));
		AddReward(new ItemReward("Vis", 2712));

		AddDialogHook("FTOWER41_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER41_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FTOWER41_SQ_05_ST", "FTOWER41_SQ_05", "I'll go and check on it", "It will be fine"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
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
			await dialog.Msg("FTOWER41_SQ_05_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

