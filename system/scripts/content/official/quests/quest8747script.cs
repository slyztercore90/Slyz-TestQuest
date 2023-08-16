//--- Melia Script -----------------------------------------------------------
// The Task of Gaining the Mind [Sadhu]
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

[QuestScript(8747)]
public class Quest8747Script : QuestScript
{
	protected override void Load()
	{
		SetId(8747);
		SetName("The Task of Gaining the Mind [Sadhu]");
		SetDescription("Talk to the Sadhu Master");
		SetTrack("SProgress", "ESuccess", "JOB_HOPLITE5_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(185));

		AddObjective("kill0", "Kill 1 Colimencia", new KillObjective(57189, 1));

		AddDialogHook("JOB_SADU3_1_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_SADU3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_SADU5_1_01", "JOB_SADU5_1", "Ask what to do", "Tell him it won't be helpful"))
			{
				case 1:
					await dialog.Msg("JOB_SADU5_1_02");
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
			await dialog.Msg("JOB_SADU5_1_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

