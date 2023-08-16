//--- Melia Script -----------------------------------------------------------
// Purification Research(2) 
//--- Description -----------------------------------------------------------
// Quest to Talk with Loremaster Emmanuelis.
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

[QuestScript(90219)]
public class Quest90219Script : QuestScript
{
	protected override void Load()
	{
		SetId(90219);
		SetName("Purification Research(2) ");
		SetDescription("Talk with Loremaster Emmanuelis");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_3_SQ_80"));
		AddPrerequisite(new LevelPrerequisite(335));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));

		AddDialogHook("CORAL_44_3_MAN1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_3_MAN1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_3_SQ_90_ST", "CORAL_44_3_SQ_90", "How can I do it?", "That's too difficult to do now"))
			{
				case 1:
					await dialog.Msg("CORAL_44_3_SQ_90_AG");
					dialog.UnHideNPC("CORAL_44_3_SQ_90_DARK");
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
			await dialog.Msg("CORAL_44_3_SQ_90_SU");
			dialog.HideNPC("CORAL_44_3_SQ_90_DARK");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

