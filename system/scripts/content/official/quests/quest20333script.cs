//--- Melia Script -----------------------------------------------------------
// The Last Key
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

[QuestScript(20333)]
public class Quest20333Script : QuestScript
{
	protected override void Load()
	{
		SetId(20333);
		SetName("The Last Key");
		SetDescription("Talk to Bishop Aurelius");
		SetTrack("SProgress", "EComplete", "CHATHEDRAL56_MQ05_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL56_MQ04"));
		AddPrerequisite(new LevelPrerequisite(159));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL56_SQ01_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 11));
		AddReward(new ItemReward("Vis", 4611));

		AddDialogHook("CHATHEDRAL_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL56_MQ05_PUZZLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL56_MQ05_select01", "CHATHEDRAL56_MQ05", "I will find the key", "Give me some time"))
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
			await dialog.Msg("EffectLocalNPC/CHATHEDRAL56_MQ05_PUZZLE/F_spin022_blue/0.5/BOT");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Acquired Maven's key!");
			await dialog.Msg("CHATHEDRAL56_MQ05_PUZZLE_ED");
			// Func/SCR_CHATHEDRAL56_MQ05_LAYER;
			// Func/CHATHEDRAL56_BISHOP_APPEAR;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

