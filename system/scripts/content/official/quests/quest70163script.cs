//--- Melia Script -----------------------------------------------------------
// Mission to Retake the Monastery (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Goss.
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

[QuestScript(70163)]
public class Quest70163Script : QuestScript
{
	protected override void Load()
	{
		SetId(70163);
		SetName("Mission to Retake the Monastery (4)");
		SetDescription("Talk to Senior Monk Goss");
		SetTrack("SPossible", "ESuccess", "ABBEY39_4_MQ04_TRACK", "m_boss_d");

		AddPrerequisite(new CompletedPrerequisite("ABBEY39_4_MQ03"));
		AddPrerequisite(new LevelPrerequisite(183));

		AddObjective("kill0", "Kill 1 Tetraox", new KillObjective(57421, 1));

		AddReward(new ExpReward(1884006, 1884006));
		AddReward(new ItemReward("expCard9", 5));
		AddReward(new ItemReward("Vis", 5673));

		AddDialogHook("ABBEY394_MQ_04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBEY39_4_MQ_04_1", "ABBEY39_4_MQ04", "Let's go to the Prayer Room", "Rest together"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY39_4_MQ05");
	}
}

