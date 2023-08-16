//--- Melia Script -----------------------------------------------------------
// Swiftness [Wugushi Advancement]
//--- Description -----------------------------------------------------------
// Quest to Call for the Wugushi Submaster .
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

[QuestScript(8736)]
public class Quest8736Script : QuestScript
{
	protected override void Load()
	{
		SetId(8736);
		SetName("Swiftness [Wugushi Advancement]");
		SetDescription("Call for the Wugushi Submaster ");
		SetTrack("SProgress", "ESuccess", "JOB_WUGU5_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Rajatoad", new KillObjective(57184, 1));

		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_WUGU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_WUGU5_1_01", "JOB_WUGU5_1", "I'll go there", "Tell him its too dangerous"))
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
			await dialog.Msg("JOB_WUGU5_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

