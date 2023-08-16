//--- Melia Script -----------------------------------------------------------
// Alarm Installation (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90150)]
public class Quest90150Script : QuestScript
{
	protected override void Load()
	{
		SetId(90150);
		SetName("Alarm Installation (2)");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_100"));
		AddPrerequisite(new LevelPrerequisite(295));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_DCAPITAL_20_6_SQ_110_ST", "F_DCAPITAL_20_6_SQ_110", "I will be back in a zippy.", "I am far too tired and wired."))
			{
				case 1:
					await dialog.Msg("F_DCAPITAL_20_6_SQ_110_AG");
					dialog.UnHideNPC("DCAPITAL_20_6_SQ_110_1");
					dialog.UnHideNPC("DCAPITAL_20_6_SQ_110_2");
					dialog.UnHideNPC("DCAPITAL_20_6_SQ_110_3");
					dialog.UnHideNPC("DCAPITAL_20_6_SQ_110_4");
					dialog.UnHideNPC("DCAPITAL_20_6_SQ_110_5");
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
			await dialog.Msg("F_DCAPITAL_20_6_SQ_110_SU");
			dialog.AddonMessage("NOTICE_Dm_Clear", "You have survived a formidable experience!{nl}Speak with the Wings of Vaivora NPC to record your experience and collect your reward!");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

