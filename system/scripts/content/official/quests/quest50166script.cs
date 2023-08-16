//--- Melia Script -----------------------------------------------------------
// Village Curse (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Village Priest Chaleims.
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

[QuestScript(50166)]
public class Quest50166Script : QuestScript
{
	protected override void Load()
	{
		SetId(50166);
		SetName("Village Curse (1)");
		SetDescription("Talk to Village Priest Chaleims");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ1"));
		AddPrerequisite(new LevelPrerequisite(246));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_PEAPLE1_3", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_72_SQ2_startnpc1", "TABLELAND_72_SQ2", "Alright, I'll help you", "I don't think that's something I can do."))
			{
				case 1:
					await dialog.Msg("TABLELAND_72_SQ2_startnpc2");
					await dialog.Msg("FadeOutIN/1000");
					dialog.UnHideNPC("TABLE72_PEAPLE1_1");
					dialog.UnHideNPC("TABLE72_PEAPLE5");
					dialog.HideNPC("TABLE72_PEAPLE1_3");
					dialog.HideNPC("TABLE72_PEAPLE5_1");
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
			await dialog.Msg("TABLELAND_72_SQ2_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

