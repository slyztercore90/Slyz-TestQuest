//--- Melia Script -----------------------------------------------------------
// The Evening Star at Night
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Aldona.
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

[QuestScript(60016)]
public class Quest60016Script : QuestScript
{
	protected override void Load()
	{
		SetId(60016);
		SetName("The Evening Star at Night");
		SetDescription("Talk to Kupole Aldona");
		SetTrack("SProgress", "ESuccess", "VPRISON514_MQ_05_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("VPRISON514_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(157));

		AddObjective("kill0", "Kill 1 Dionys", new KillObjective(103013, 1));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 36424));

		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_ALDONA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("VPRISON514_MQ_05_01_1", "VPRISON514_MQ_05", "I am ready", "I will prepare a little more"))
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
			// Func/VPRISON514_MQ_05_AFTER_RUN;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

