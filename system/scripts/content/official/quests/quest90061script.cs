//--- Melia Script -----------------------------------------------------------
// Purification Ceremony (2)
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

[QuestScript(90061)]
public class Quest90061Script : QuestScript
{
	protected override void Load()
	{
		SetId(90061);
		SetName("Purification Ceremony (2)");
		SetDescription("Talk to Dievdirbys Asel");
		SetTrack("SPossible", "ESuccess", "KATYN_45_3_SQ_7_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(253));

		AddReward(new ExpReward(1970122, 1970122));
		AddReward(new ItemReward("expCard12", 4));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_AJEL4", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_AJEL4", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_45_3_SQ_7_ST", "KATYN_45_3_SQ_7", "I will protect you", "Please wait a bit"))
			{
				case 1:
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
			await dialog.Msg("KATYN_45_3_SQ_7_SU");
			dialog.HideNPC("KATYN_45_3_DARKSMOKE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

