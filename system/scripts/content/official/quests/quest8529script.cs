//--- Melia Script -----------------------------------------------------------
// Recapture the Bell Tower
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Algis.
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

[QuestScript(8529)]
public class Quest8529Script : QuestScript
{
	protected override void Load()
	{
		SetId(8529);
		SetName("Recapture the Bell Tower");
		SetDescription("Talk to Follower Algis");
		SetTrack("SProgress", "ESuccess", "CHAPLE577_MQ_02_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(48));

		AddObjective("kill0", "Kill 1 Necroventer", new KillObjective(41230, 1));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));
		AddReward(new ItemReward("Vis", 720));

		AddDialogHook("CHAPLE577_ARUNE_01", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE577_MQ_02_01", "CHAPLE577_MQ_02", "Begin immediately", "Gesti might still be around"))
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
			await dialog.Msg("CHAPLE577_MQ_02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

