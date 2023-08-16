//--- Melia Script -----------------------------------------------------------
// Proper Price [Peltasta Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Peltasta Master.
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

[QuestScript(17710)]
public class Quest17710Script : QuestScript
{
	protected override void Load()
	{
		SetId(17710);
		SetName("Proper Price [Peltasta Advancement]");
		SetDescription("Talk to the Peltasta Master");
		SetTrack("SProgress", "ESuccess", "JOB_PELTASTA5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Gaigalas", new KillObjective(57188, 1));

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA5_1_select", "JOB_PELTASTA5_1", "I can do anything", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_PELTASTA5_1_AG");
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
			await dialog.Msg("JOB_PELTASTA5_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

