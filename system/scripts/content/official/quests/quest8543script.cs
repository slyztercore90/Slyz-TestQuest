//--- Melia Script -----------------------------------------------------------
// Bull Hunting
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Kayetonas.
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

[QuestScript(8543)]
public class Quest8543Script : QuestScript
{
	protected override void Load()
	{
		SetId(8543);
		SetName("Bull Hunting");
		SetDescription("Talk to Follower Kayetonas");
		SetTrack("SProgress", "ESuccess", "GELE573_MQ_06_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(32));

		AddObjective("kill0", "Kill 1 Minotaur", new KillObjective(41383, 1));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("GELE573_KAROLINA", "BeforeStart", BeforeStart);
		AddDialogHook("GELE573_KAROLINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GELE573_MQ_06_01", "GELE573_MQ_06", "I'll go with you", "About the Followers", "I need to prepare myself"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("GELE573_MQ_06_add");
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
			await dialog.Msg("GELE573_MQ_06_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

