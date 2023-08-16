//--- Melia Script -----------------------------------------------------------
// Suspicious Movement (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Master.
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

[QuestScript(90171)]
public class Quest90171Script : QuestScript
{
	protected override void Load()
	{
		SetId(90171);
		SetName("Suspicious Movement (2)");
		SetDescription("Talk to the Linker Master");
		SetTrack("SProgress", "ESuccess", "LOWLV_EYEOFBAIGA_SQ_20_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("LOWLV_EYEOFBAIGA_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(290));

		AddObjective("kill0", "Kill 6 Yellow Gazing Golem(s)", new KillObjective(107023, 6));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("misc_ore17", 1));
		AddReward(new ItemReward("Vis", 12180));

		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_LINKER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("LOWLV_EYEOFBAIGA_SQ_20_ST", "LOWLV_EYEOFBAIGA_SQ_20", "Of course, there is no point in stopping now.", "I have done my part."))
			{
				case 1:
					await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_20_AG");
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
			await dialog.Msg("LOWLV_EYEOFBAIGA_SQ_20_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

