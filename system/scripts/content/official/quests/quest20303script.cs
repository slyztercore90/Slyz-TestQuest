//--- Melia Script -----------------------------------------------------------
// Mercy and Salvation (1)
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

[QuestScript(20303)]
public class Quest20303Script : QuestScript
{
	protected override void Load()
	{
		SetId(20303);
		SetName("Mercy and Salvation (1)");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack("SProgress", "ESuccess", "CHATHEDRAL53_MQ04_TRACK", "CHATHEDRAL53_MQ04_PG");

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ03"));
		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL53_MQ04_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_MQ04_HINT", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL53_MQ04_select01", "CHATHEDRAL53_MQ04", "I will look for the divine artifacts of the mercy", "Decline"))
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
			dialog.AddonMessage("NOTICE_Dm_Clear", "A teardrop-shaped jewel appeared from the device");
			// Func/CHATHEDRAL56_BISHOP_APPEAR;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CHATHEDRAL53_MQ05");
	}
}

