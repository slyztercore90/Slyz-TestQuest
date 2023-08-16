//--- Melia Script -----------------------------------------------------------
// Focus Training
//--- Description -----------------------------------------------------------
// Quest to Talk with the Onmyoji Master.
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

[QuestScript(80401)]
public class Quest80401Script : QuestScript
{
	protected override void Load()
	{
		SetId(80401);
		SetName("Focus Training");
		SetDescription("Talk with the Onmyoji Master");
		SetTrack("SProgress", "ESuccess", "JOB_ONMYOJI_Q1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(285));

		AddDialogHook("ONMYOJI_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("ONMYOJI_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ONMYOJI_Q1_ST1", "JOB_ONMYOJI_Q1", "I'll give it a shot.", "Sounds like too much trouble."))
			{
				case 1:
					await dialog.Msg("JOB_ONMYOJI_Q1_AFST");
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
			await dialog.Msg("JOB_ONMYOJI_Q1_SU1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

