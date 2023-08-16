//--- Melia Script -----------------------------------------------------------
// Observing the Owl (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Asel.
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

[QuestScript(90056)]
public class Quest90056Script : QuestScript
{
	protected override void Load()
	{
		SetId(90056);
		SetName("Observing the Owl (2)");
		SetDescription("Talk to Dievdirbys Asel");
		SetTrack("SSuccess", "ESuccess", "KATYN_45_3_SQ_2_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_1"));
		AddPrerequisite(new LevelPrerequisite(253));

		AddDialogHook("KATYN_45_3_AJEL2", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_OWL4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_45_3_SQ_2_ST", "KATYN_45_3_SQ_2", "Let's go.", "Please wait a little."))
			{
				case 1:
					// Func/SCR_KATYN_45_3_SQ_3_NPC_RUN;
					dialog.HideNPC("KATYN_45_3_AJEL2");
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
			dialog.UnHideNPC("KATYN_45_3_AJEL3");
			// Func/SCR_KATYN_45_3_SQ_3_SUCC_RUN;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

