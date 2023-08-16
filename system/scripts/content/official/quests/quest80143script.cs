//--- Melia Script -----------------------------------------------------------
// Deranged Goddess (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Serija.
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

[QuestScript(80143)]
public class Quest80143Script : QuestScript
{
	protected override void Load()
	{
		SetId(80143);
		SetName("Deranged Goddess (1)");
		SetDescription("Talk to Kupole Serija");

		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_3_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(294));

		AddReward(new ExpReward(41922440, 41922440));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 12348));

		AddDialogHook("LIMESTONECAVE_52_3_SERIJA_3", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_3_DALIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LIMESTONE_52_3_MQ_7_start", "LIMESTONE_52_3_MQ_7", "Alright", "I don't want to do that, I'm scared."))
			{
				case 1:
					// Func/LIMESTONE_52_3_REENTER_RUN;
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
			await dialog.Msg("LIMESTONE_52_3_MQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

