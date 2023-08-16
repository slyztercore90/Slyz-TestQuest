//--- Melia Script -----------------------------------------------------------
// Activate the Central Altar
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Donatas.
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

[QuestScript(8518)]
public class Quest8518Script : QuestScript
{
	protected override void Load()
	{
		SetId(8518);
		SetName("Activate the Central Altar");
		SetDescription("Talk to Follower Donatas");
		SetTrack("SProgress", "ESuccess", "CHAPLE576_MQ_09_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_04_1"));
		AddPrerequisite(new LevelPrerequisite(44));

		AddObjective("kill0", "Kill 1 Mallet Wyvern", new KillObjective(47502, 1));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 660));

		AddDialogHook("CHAPEL576_DONATAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL576_DONATAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE576_MQ_09_01", "CHAPLE576_MQ_09", "I'll check on it", "About the Church's altar", "I'll wait a little bit"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("CHAPLE576_MQ_09_add");
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
			await dialog.Msg("CHAPLE576_MQ_09_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

