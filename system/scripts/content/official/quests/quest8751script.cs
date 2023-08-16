//--- Melia Script -----------------------------------------------------------
// Advisor's Choice [Oracle Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Oracle Master.
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

[QuestScript(8751)]
public class Quest8751Script : QuestScript
{
	protected override void Load()
	{
		SetId(8751);
		SetName("Advisor's Choice [Oracle Advancement]");
		SetDescription("Call of the Oracle Master");
		SetTrack("SProgress", "ESuccess", "JOB_ORACLE5_1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Oracle Master", new KillObjective(57224, 1));

		AddDialogHook("MASTER_ORACLE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_ORACLE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ORACLE5_1_01", "JOB_ORACLE5_1", "I'll accept the duel", "Avoid the duel"))
			{
				case 1:
					await dialog.Msg("JOB_ORACLE5_1_04");
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
			await dialog.Msg("JOB_ORACLE5_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

