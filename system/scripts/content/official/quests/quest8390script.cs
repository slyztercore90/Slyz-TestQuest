//--- Melia Script -----------------------------------------------------------
// The Guardian's Jar (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Secret Guardian.
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

[QuestScript(8390)]
public class Quest8390Script : QuestScript
{
	protected override void Load()
	{
		SetId(8390);
		SetName("The Guardian's Jar (3)");
		SetDescription("Talk to the Secret Guardian");
		SetTrack("SProgress", "ESuccess", "ZACHA5F_MQ_03_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ZACHA5F_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(93));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 69));
		AddReward(new ItemReward("ZACHA5F_MQ03_POT", 1));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("ZACHARIEL_GUARDIAN", "BeforeStart", BeforeStart);
		AddDialogHook("ZACHARIEL_GUARDIAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ZACHA5F_MQ_03_01", "ZACHA5F_MQ_03", "Yes, I'll make sure to fill the jar with the guardian's will", "I'm not ready yet"))
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

