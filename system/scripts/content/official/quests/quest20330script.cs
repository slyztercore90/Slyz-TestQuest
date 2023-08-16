//--- Melia Script -----------------------------------------------------------
// Adapting to Circumstances (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Bishop Aurelius.
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

[QuestScript(20330)]
public class Quest20330Script : QuestScript
{
	protected override void Load()
	{
		SetId(20330);
		SetName("Adapting to Circumstances (3)");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack("SProgress", "ESuccess", "CHATHEDRAL56_MQ02_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ02_1"));
		AddPrerequisite(new LevelPrerequisite(145));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("CHATHEDRAL56_MQ02_ITEM", 1));
		AddReward(new ItemReward("Vis", 3770));

		AddDialogHook("CHATHEDRAL56_MQ_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_MQ02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL56_MQ02_select01", "CHATHEDRAL56_MQ02", "I will complete the scroll", "Give me some time to prepare"))
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

