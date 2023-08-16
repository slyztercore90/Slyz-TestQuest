//--- Melia Script -----------------------------------------------------------
// Activities of a Linker [Linker Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Linker Submaster.
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

[QuestScript(17640)]
public class Quest17640Script : QuestScript
{
	protected override void Load()
	{
		SetId(17640);
		SetName("Activities of a Linker [Linker Advancement]");
		SetDescription("Talk to the Linker Submaster");
		SetTrack("SProgress", "ESuccess", "JOB_LINKER4_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Vubbe Fighter", new KillObjective(57166, 1));

		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_LINKER2_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_LINKER4_1_select", "JOB_LINKER4_1", "I will get rid of the Vubbe Fighter", "Cancel"))
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
			await dialog.Msg("JOB_LINKER4_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

