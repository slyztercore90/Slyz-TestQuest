//--- Melia Script -----------------------------------------------------------
// Restrain to Protect (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kabbalist Lutas.
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

[QuestScript(80112)]
public class Quest80112Script : QuestScript
{
	protected override void Load()
	{
		SetId(80112);
		SetName("Restrain to Protect (2)");
		SetDescription("Talk to Kabbalist Lutas");

		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_13"));
		AddPrerequisite(new LevelPrerequisite(226));

		AddReward(new ExpReward(1623069, 1623069));
		AddReward(new ItemReward("expCard11", 1));
		AddReward(new ItemReward("Vis", 89496));

		AddDialogHook("CORAL_35_2_LUTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_35_2_SQ_14_start", "CORAL_35_2_SQ_14", "How can I help you?", "I'm busy now"))
			{
				case 1:
					await dialog.Msg("CORAL_35_2_SQ_14_agree");
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
			await dialog.Msg("CORAL_35_2_SQ_14_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

