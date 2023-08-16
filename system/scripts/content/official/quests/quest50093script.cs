//--- Melia Script -----------------------------------------------------------
// Rose's Friends (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Traveling Merchant Cassias.
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

[QuestScript(50093)]
public class Quest50093Script : QuestScript
{
	protected override void Load()
	{
		SetId(50093);
		SetName("Rose's Friends (3)");
		SetDescription("Talk to Traveling Merchant Cassias");
		SetTrack("SProgress", "ESuccess", "BRACKEN_63_1_MQ040_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_1_MQ030"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 9 Vubbe Chaser(s)", new KillObjective(103023, 9));

		AddReward(new ExpReward(26860, 26860));
		AddReward(new ItemReward("expCard2", 2));
		AddReward(new ItemReward("Vis", 3654));

		AddDialogHook("BRACKEN631_TRADESMAN05", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN631_ROZE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN_63_1_MQ040_startnpc01", "BRACKEN_63_1_MQ040", "Let's go back to the Herb Gatherers' Cabin", "Let's rest for a while."))
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

