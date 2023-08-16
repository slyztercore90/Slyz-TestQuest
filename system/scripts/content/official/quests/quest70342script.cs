//--- Melia Script -----------------------------------------------------------
// Reduce the Source of Pain [Sadhu Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sadhu Master.
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

[QuestScript(70342)]
public class Quest70342Script : QuestScript
{
	protected override void Load()
	{
		SetId(70342);
		SetName("Reduce the Source of Pain [Sadhu Advancement]");
		SetDescription("Talk to the Sadhu Master");
		SetTrack("SProgress", "ESuccess", "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(57189, 1));

		AddDialogHook("JOB_2_SADHU_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SADHU_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_SADHU6_1_1", "JOB_2_SADHU6", "Ask what to do", "Tell him it won't be helpful"))
			{
				case 1:
					await dialog.Msg("JOB_2_SADHU6_1_2");
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

