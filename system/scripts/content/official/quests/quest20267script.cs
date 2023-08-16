//--- Melia Script -----------------------------------------------------------
// Something Blasphemous
//--- Description -----------------------------------------------------------
// Quest to Talk to Believer Onute.
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

[QuestScript(20267)]
public class Quest20267Script : QuestScript
{
	protected override void Load()
	{
		SetId(20267);
		SetName("Something Blasphemous");
		SetDescription("Talk to Believer Onute");
		SetTrack("SProgress", "ESuccess", "THORN20_MQ07_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(61));

		AddObjective("kill0", "Kill 1 Archon", new KillObjective(41245, 1));
		AddObjective("kill1", "Kill 1 Demon Summoning Crystal", new KillObjective(153029, 1));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("HAND02_121", 1));
		AddReward(new ItemReward("Vis", 1159));

		AddDialogHook("THORN20_MQ07_TRACK", "BeforeStart", BeforeStart);
		AddDialogHook("THORN20_MQ07_TRACK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN20_MQ07_select01", "THORN20_MQ07", "I'll defeat Archon", "Leave the vicinity"))
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
			await dialog.Msg("THORN20_MQ07_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

