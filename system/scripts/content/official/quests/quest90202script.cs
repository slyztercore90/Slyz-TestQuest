//--- Melia Script -----------------------------------------------------------
// Sealed Relic
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90202)]
public class Quest90202Script : QuestScript
{
	protected override void Load()
	{
		SetId(90202);
		SetName("Sealed Relic");
		SetDescription("Speak with Loremaster Ugnius");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_20"));
		AddPrerequisite(new LevelPrerequisite(331));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_2_SQ_30_ST", "CORAL_44_2_SQ_30", "What do I have to do?", "Solve it as quickly as possible. "))
			{
				case 1:
					await dialog.Msg("CORAL_44_2_SQ_30_AG");
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
			await dialog.Msg("CORAL_44_2_SQ_30_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

