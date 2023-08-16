//--- Melia Script -----------------------------------------------------------
// Historical Theft [Cryomancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(12005)]
public class Quest12005Script : QuestScript
{
	protected override void Load()
	{
		SetId(12005);
		SetName("Historical Theft [Cryomancer Advancement]");
		SetDescription("Talk to the Cryomancer Master");
		SetTrack("SProgress", "ESuccess", "JOB_ICEMAGE1_TRACK");

		AddPrerequisite(new LevelPrerequisite(15));

		AddObjective("kill0", "Kill 3 Black Spectra(s)", new KillObjective(57728, 3));

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ICEMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ICEMAGE1_select1", "JOB_ICEMAGE1", "I'll do it", "It looks dangerous"))
			{
				case 1:
					await dialog.Msg("JOB_ICEMAGE1_AG");
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
			await dialog.Msg("JOB_ICEMAGE1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

