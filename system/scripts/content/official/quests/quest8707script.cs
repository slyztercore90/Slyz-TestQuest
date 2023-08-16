//--- Melia Script -----------------------------------------------------------
// Disturbance of the Winged Beast [Peltasta Advancement] (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Fletcher Master.
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

[QuestScript(8707)]
public class Quest8707Script : QuestScript
{
	protected override void Load()
	{
		SetId(8707);
		SetName("Disturbance of the Winged Beast [Peltasta Advancement] (3)");
		SetDescription("Talk to the Fletcher Master");
		SetTrack("SProgress", "ESuccess", "JOB_PELTASTA4_3_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("JOB_PELTASTA4_2"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Moa", new KillObjective(57157, 1));

		AddDialogHook("MASTER_FLETCHER", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_FLETCHER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA4_3_01", "JOB_PELTASTA4_3", "Is there any other way?", "Give up"))
			{
				case 1:
					await dialog.Msg("JOB_PELTASTA4_3_AG");
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
			await dialog.Msg("JOB_PELTASTA4_3_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_PELTASTA4_4");
	}
}

