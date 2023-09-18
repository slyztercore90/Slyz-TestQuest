//--- Melia Script -----------------------------------------------------------
// Sapper's Proven Abilities [Sapper Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Submaster.
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

[QuestScript(30106)]
public class Quest30106Script : QuestScript
{
	protected override void Load()
	{
		SetId(30106);
		SetName("Sapper's Proven Abilities [Sapper Advancement]");
		SetDescription("Talk to the Sapper Submaster");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "JOB_CATAPHRACT4_1_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(135));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(1, MonsterId.Boss_BiteRegina_J1));

		AddDialogHook("JOB_2_SAPPER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SAPPER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_SAPPER_5_1_select", "JOB_2_SAPPER_5_1", "Sure, I'll defeat it", "It looks dangerous"))
		{
			case 1:
				await dialog.Msg("JOB_2_SAPPER_5_1_agree");
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("JOB_2_SAPPER_5_1_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

