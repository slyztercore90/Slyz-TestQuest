//--- Melia Script -----------------------------------------------------------
// Real Experiences of Elementalist [Elementalist Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elementalist Master.
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

[QuestScript(30105)]
public class Quest30105Script : QuestScript
{
	protected override void Load()
	{
		SetId(30105);
		SetName("Real Experiences of Elementalist [Elementalist Advancement]");
		SetDescription("Talk to the Elementalist Master");
		SetTrack("SProgress", "ESuccess", "JOB_WARLOCK4_1_TRACK", "m_boss_c");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Reaverpede", new KillObjective(57169, 1));

		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_ELEMENTALIST_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_ELEMENTALIST_5_1_select", "JOB_2_ELEMENTALIST_5_1", "What should I do?", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_2_ELEMENTALIST_5_1_agree");
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
			await dialog.Msg("JOB_2_ELEMENTALIST_5_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

