//--- Melia Script -----------------------------------------------------------
// Complete the Mission of a Thaumaturge [Thaumaturge Advancement]
//--- Description -----------------------------------------------------------
// Quest to Meet the Thaumaturge Master.
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

[QuestScript(19180)]
public class Quest19180Script : QuestScript
{
	protected override void Load()
	{
		SetId(19180);
		SetName("Complete the Mission of a Thaumaturge [Thaumaturge Advancement]");
		SetDescription("Meet the Thaumaturge Master");
		SetTrack("SProgress", "ESuccess", "JOB_THAUELE5_1_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Netherbovine", new KillObjective(57175, 1));

		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_THAUMATURGE3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_THAUMATURGE5_1_ST", "JOB_THAUMATURGE5_1", "Yes", "No"))
			{
				case 1:
					await dialog.Msg("JOB_THAUMATURGE5_1_AC");
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
			await dialog.Msg("JOB_THAUMATURGE5_1_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

