//--- Melia Script -----------------------------------------------------------
// Training for Holiness [Priest Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Priest Master.
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

[QuestScript(1148)]
public class Quest1148Script : QuestScript
{
	protected override void Load()
	{
		SetId(1148);
		SetName("Training for Holiness [Priest Advancement]");
		SetDescription("Talk to the Priest Master");
		SetTrack("SProgress", "ESuccess", "JOB_PRIEST3_1_TRACK", 3000);

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Priest Master", new KillObjective(57229, 1));

		AddDialogHook("MASTER_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PRIEST3_1_select1", "JOB_PRIEST3_1", "I'll prove myself through a duel", "Avoid the duel"))
			{
				case 1:
					await dialog.Msg("JOB_PRIEST3_1_agree1");
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
			await dialog.Msg("JOB_PRIEST3_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

