//--- Melia Script -----------------------------------------------------------
// 100 Shots 100 Hits [Ranger Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call of the Ranger Master.
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

[QuestScript(8732)]
public class Quest8732Script : QuestScript
{
	protected override void Load()
	{
		SetId(8732);
		SetName("100 Shots 100 Hits [Ranger Advancement]");
		SetDescription("Call of the Ranger Master");
		SetTrack("SProgress", "ESuccess", "JOB_RANGER5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(57169, 1));

		AddDialogHook("MASTER_RANGER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_RANGER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_RANGER5_1_01", "JOB_RANGER5_1", "I'll catch the Reaverpede", "Decline"))
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
			await dialog.Msg("JOB_RANGER5_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

