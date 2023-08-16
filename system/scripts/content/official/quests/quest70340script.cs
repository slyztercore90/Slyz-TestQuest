//--- Melia Script -----------------------------------------------------------
// The Power to Lead Others [Rodelero Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Rodelero Master.
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

[QuestScript(70340)]
public class Quest70340Script : QuestScript
{
	protected override void Load()
	{
		SetId(70340);
		SetName("The Power to Lead Others [Rodelero Advancement]");
		SetDescription("Talk to the Rodelero Master");
		SetTrack("SProgress", "ESuccess", "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(57189, 1));

		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_RODELERO_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_RODELERO6_1_1", "JOB_2_RODELERO6", "I will try", "I don't think that's necessary"))
			{
				case 1:
					await dialog.Msg("JOB_2_RODELERO6_1_2");
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

		return HookResult.Continue;
	}
}

