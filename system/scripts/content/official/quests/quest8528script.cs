//--- Melia Script -----------------------------------------------------------
// Gesti's Plan
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

[QuestScript(8528)]
public class Quest8528Script : QuestScript
{
	protected override void Load()
	{
		SetId(8528);
		SetName("Gesti's Plan");
		SetDescription("Talk to Follower Algis");
		SetTrack("SProgress", "ESuccess", "CHAPLE577_MQ_01_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("CHAPLE576_MQ_04_1"));
		AddPrerequisite(new LevelPrerequisite(48));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 21));

		AddDialogHook("CHAPLE577_ARUNE_01", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE577_ARUNE_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE577_MQ_01_01", "CHAPLE577_MQ_01", "Let's go and find", "Hide first"))
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
			await dialog.Msg("CHAPLE577_MQ_01_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

