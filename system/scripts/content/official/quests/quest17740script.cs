//--- Melia Script -----------------------------------------------------------
// Problem Solving [Barbarian Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Barbarian Master.
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

[QuestScript(17740)]
public class Quest17740Script : QuestScript
{
	protected override void Load()
	{
		SetId(17740);
		SetName("Problem Solving [Barbarian Advancement]");
		SetDescription("Talk to the Barbarian Master");
		SetTrack("SProgress", "ESuccess", "JOB_BARBARIAN5_1_TRACK", "m_boss_a");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Poata", new KillObjective(57164, 1));

		AddDialogHook("JOB_BARBARIAN2_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_BARBARIAN2_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_BARBARIAN5_1_select", "JOB_BARBARIAN5_1", "What do I pay it with?", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_BARBARIAN5_1_prog");
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
			await dialog.Msg("JOB_BARBARIAN5_1_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

