//--- Melia Script -----------------------------------------------------------
// Warrior's Required Virtues [Barbarian Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk with Barbarian Submaster.
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

[QuestScript(70311)]
public class Quest70311Script : QuestScript
{
	protected override void Load()
	{
		SetId(70311);
		SetName("Warrior's Required Virtues [Barbarian Advancement]");
		SetDescription("Talk with Barbarian Submaster");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 30 Gosaru(s)", new KillObjective(30, MonsterId.Gosaru));

		AddDialogHook("JOB_2_BARBARIAN_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_BARBARIAN_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("JOB_2_BARABARIAN3_1_1", "JOB_2_BARBARIAN3", "Yes. That is.", "It's not the time for it"))
		{
			case 1:
				await dialog.Msg("JOB_2_BARABARIAN3_1_2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

