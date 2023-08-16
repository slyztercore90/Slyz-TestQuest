//--- Melia Script -----------------------------------------------------------
// Sea Magic Circle
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

[QuestScript(80107)]
public class Quest80107Script : QuestScript
{
	protected override void Load()
	{
		SetId(80107);
		SetName("Sea Magic Circle");
		SetDescription("Talk to Kabbalist Lutas");
		SetTrack("SProgress", "ESuccess", "CORAL_35_2_SQ_9_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_8"));
		AddPrerequisite(new LevelPrerequisite(226));

		AddReward(new ExpReward(3246138, 3246138));
		AddReward(new ItemReward("expCard11", 2));
		AddReward(new ItemReward("Vis", 8136));

		AddDialogHook("CORAL_35_2_LUTAS_2", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_35_2_LUTAS_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_35_2_SQ_9_start", "CORAL_35_2_SQ_9", "I'll go there.", "That's going to be difficult."))
			{
				case 1:
					// Func/CORAL_35_2_HIDE_FUNC;
					dialog.HideNPC("CORAL_35_2_LUTAS_2");
					dialog.UnHideNPC("CORAL_35_2_LUTAS_3");
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
			await dialog.Msg("CORAL_35_2_SQ_9_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

