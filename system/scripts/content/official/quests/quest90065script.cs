//--- Melia Script -----------------------------------------------------------
// Memories of the Sleeping Owl
//--- Description -----------------------------------------------------------
// Quest to Talk to Kind Owl Sculpture.
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

[QuestScript(90065)]
public class Quest90065Script : QuestScript
{
	protected override void Load()
	{
		SetId(90065);
		SetName("Memories of the Sleeping Owl");
		SetDescription("Talk to Kind Owl Sculpture");
		SetTrack("SProgress", "EProgress", "KATYN_45_3_SQ_11_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("KATYN_45_3_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(253));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10120));

		AddDialogHook("KATYN_45_3_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN_45_3_AJEL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN_45_3_SQ_11_ST", "KATYN_45_3_SQ_11", "I'll hand you the sculpture.", "Please wait a bit"))
			{
				case 1:
					await dialog.Msg("EffectLocalNPC/KATYN_45_3_OWL3/F_light018_yellow/2/MID");
					await dialog.Msg("KATYN_45_3_SQ_11_AG");
					dialog.HideNPC("KATYN_45_3_AJEL4");
					dialog.UnHideNPC("KATYN_45_3_AJEL3");
					dialog.HideNPC("KATYN_45_3_SCULPT");
					dialog.HideNPC("KATYN_45_3_OWL4");
					dialog.UnHideNPC("KATYN_45_3_OWL4PURI");
					dialog.HideNPC("KATYN_45_3_SCULPT2");
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
			await dialog.Msg("KATYN_45_3_SQ_11_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

