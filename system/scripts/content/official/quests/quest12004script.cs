//--- Melia Script -----------------------------------------------------------
// Academic Question [Pyromancer Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(12004)]
public class Quest12004Script : QuestScript
{
	protected override void Load()
	{
		SetId(12004);
		SetName("Academic Question [Pyromancer Advancement]");
		SetDescription("Talk to the Pyromancer Master");
		SetTrack("SProgress", "ESuccess", "JOB_FIREMAGE1_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(15));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FIREMAGE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_FIREMAGE1_select1", "JOB_FIREMAGE1", "I'll help with the research", "I'll come back next time"))
			{
				case 1:
					await dialog.Msg("JOB_FIREMAGE1_AG");
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
			await dialog.Msg("JOB_FIREMAGE_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

