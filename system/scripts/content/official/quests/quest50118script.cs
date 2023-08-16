//--- Melia Script -----------------------------------------------------------
// The Rescue (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Rose.
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

[QuestScript(50118)]
public class Quest50118Script : QuestScript
{
	protected override void Load()
	{
		SetId(50118);
		SetName("The Rescue (2)");
		SetDescription("Talk to Traveling Merchant Rose");
		SetTrack("SProgress", "ESuccess", "ABBAY_64_1_MQ020_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_1_MQ010"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 4 Canyon Area Device 5(s)", new KillObjective(47106, 4));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Drug_SP1_Q", 45));
		AddReward(new ItemReward("Vis", 675));

		AddDialogHook("ABBEY641_ROZE01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY641_MONK01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBAY_64_1_MQ020_startnpc01", "ABBAY_64_1_MQ020", "We should hurry", "Look for another way"))
			{
				case 1:
					await dialog.Msg("ABBAY_64_1_MQ020_AG");
					dialog.HideNPC("ABBEY641_ROZE01");
					await dialog.Msg("FadeOutIN/1000");
					dialog.UnHideNPC("ABBEY641_ROZE02");
					dialog.UnHideNPC("ABBEY641_MONK01");
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

		return HookResult.Continue;
	}
}

