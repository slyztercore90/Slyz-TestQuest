//--- Melia Script -----------------------------------------------------------
// To Novaha Monastery
//--- Description -----------------------------------------------------------
// Quest to Follow Traveling Merchant Rose to the entrance of the Novaha Monastery.
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

[QuestScript(50112)]
public class Quest50112Script : QuestScript
{
	protected override void Load()
	{
		SetId(50112);
		SetName("To Novaha Monastery");
		SetDescription("Follow Traveling Merchant Rose to the entrance of the Novaha Monastery");
		SetTrack("SProgress", "ESuccess", "BRACKEN_63_3_MQ050_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_MQ040"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Gremlin", new KillObjective(57455, 1));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 5040));

		AddDialogHook("BRACKEN633_ROZE02", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_ROZE02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("BRACKEN_63_3_MQ050_startnpc01", "BRACKEN_63_3_MQ050", "I'll defeat the demons", "Let's wait until the demons disappear"))
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

