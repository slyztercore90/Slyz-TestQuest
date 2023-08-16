//--- Melia Script -----------------------------------------------------------
// Praying for Their Rest (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Necromancer Lemija.
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

[QuestScript(80057)]
public class Quest80057Script : QuestScript
{
	protected override void Load()
	{
		SetId(80057);
		SetName("Praying for Their Rest (2)");
		SetDescription("Talk with Necromancer Lemija");

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_11_1_SQ_05"));
		AddPrerequisite(new LevelPrerequisite(208));

		AddReward(new ExpReward(541023, 541023));
		AddReward(new ItemReward("expCard11", 3));
		AddReward(new ItemReward("Vis", 7280));

		AddDialogHook("TABLELAND_11_1_LEMIJA2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLELAND_11_1_LEMIJA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_11_1_SQ_06_start", "TABLELAND_11_1_SQ_06", "Yeah, I'll collect them", "I can't do it anymore"))
			{
				case 1:
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
			await dialog.Msg("TABLELAND_11_1_SQ_06_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

