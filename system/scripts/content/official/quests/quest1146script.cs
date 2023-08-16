//--- Melia Script -----------------------------------------------------------
// Prove You are the Owner of the Shield [Peltasta Advancement]
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

[QuestScript(1146)]
public class Quest1146Script : QuestScript
{
	protected override void Load()
	{
		SetId(1146);
		SetName("Prove You are the Owner of the Shield [Peltasta Advancement]");
		SetDescription("Talk to the Peltasta Master");
		SetTrack("SProgress", "ESuccess", "JOB_PYROMANCER3_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(85));

		AddObjective("kill0", "Kill 1 Chapparition", new KillObjective(57154, 1));

		AddDialogHook("MASTER_PELTASTA", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_PELTASTA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_PELTASTA3_1_select1", "JOB_PELTASTA3_1", "I will prove it", "I'm scared, so I'll pass."))
			{
				case 1:
					await dialog.Msg("JOB_PELTASTA3_1_agree1");
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
			await dialog.Msg("JOB_PELTASTA3_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

