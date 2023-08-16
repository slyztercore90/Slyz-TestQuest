//--- Melia Script -----------------------------------------------------------
// Rescue Edmundas (3)
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

[QuestScript(50127)]
public class Quest50127Script : QuestScript
{
	protected override void Load()
	{
		SetId(50127);
		SetName("Rescue Edmundas (3)");
		SetDescription("Talk to Traveling Merchant Rose");
		SetTrack("SProgress", "ESuccess", "ABBAY_64_2_MQ030_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_2_MQ020"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 4 Magic Stone of Mutuality(s)", new KillObjective(153069, 4));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_ROZE02", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_EDMONDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBAY_64_2_MQ030_startnpc01", "ABBAY_64_2_MQ030", "I'll take a look around the vestry", "I'm going to rest for a while"))
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

		return HookResult.Continue;
	}
}

