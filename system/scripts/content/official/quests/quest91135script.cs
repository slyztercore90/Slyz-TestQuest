//--- Melia Script -----------------------------------------------------------
// Securing the Entrance (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the General Ramin.
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

[QuestScript(91135)]
public class Quest91135Script : QuestScript
{
	protected override void Load()
	{
		SetId(91135);
		SetName("Securing the Entrance (1)");
		SetDescription("Talk to the General Ramin");
		SetTrack("SProgress", "ESuccess", "EP14_2_DCASTLE1_MQ_2_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_2_DCASTLE1_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddObjective("kill0", "Kill 10 Blickferret Spearman(s) or Blickferret Fighter(s)", new KillObjective(10, 59740, 59741));

		AddReward(new ExpReward(1200000000, 1200000000));
		AddReward(new ItemReward("Vis", 30245));

		AddDialogHook("EP14_2_1_Lamin1", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_2_DCASTLE1_MQ_2_DLG1", "EP14_2_DCASTLE1_MQ_2", "Alright", "I will come back after I'm done with other errands."))
			{
				case 1:
					dialog.HideNPC("EP14_2_1_Lamin1");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

