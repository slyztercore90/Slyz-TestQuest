//--- Melia Script -----------------------------------------------------------
// A Vessel for a Spirit (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Bishop Aurelius.
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

[QuestScript(20301)]
public class Quest20301Script : QuestScript
{
	protected override void Load()
	{
		SetId(20301);
		SetName("A Vessel for a Spirit (2)");
		SetDescription("Talk with Bishop Aurelius");

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL53_MQ01"));
		AddPrerequisite(new LevelPrerequisite(137));

		AddReward(new ExpReward(2351304, 2351304));
		AddReward(new ItemReward("CHATHEDRAL53_MQ03_ITEM", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 10));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_MQ_BISHOP", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_MQ03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHATHEDRAL53_MQ02_select", "CHATHEDRAL53_MQ02", "I will find the scripture", "I need some time to prepare"))
			{
				case 1:
					await dialog.Msg("CHATHEDRAL53_MQ02_startnpc01");
					// Func/BOOK_UNHIDE/0;
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("EffectLocalNPC/CHATHEDRAL53_MQ03/F_archer_concentration_shot_lineup/2/BOT");
			dialog.AddonMessage("NOTICE_Dm_Clear", "Completed the scripture for the spirit");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

