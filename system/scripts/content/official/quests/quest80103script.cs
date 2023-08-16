//--- Melia Script -----------------------------------------------------------
// Earth Magic Circle
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

[QuestScript(80103)]
public class Quest80103Script : QuestScript
{
	protected override void Load()
	{
		SetId(80103);
		SetName("Earth Magic Circle");
		SetDescription("Talk to Kabbalist Lutas");

		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_4"));
		AddPrerequisite(new LevelPrerequisite(226));

		AddDialogHook("CORAL_35_2_LUTAS", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_35_2_SQ_5_start", "CORAL_35_2_SQ_5", "Alright, I'll help you", "Decline"))
			{
				case 1:
					await dialog.Msg("CORAL_35_2_SQ_5_start_agree");
					dialog.HideNPC("CORAL_35_2_LUTAS");
					// Func/CORAL_35_2_SQ_5_NPC;
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
			await dialog.Msg("CORAL_35_2_SQ_5_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

