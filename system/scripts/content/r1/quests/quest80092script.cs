//--- Melia Script -----------------------------------------------------------
// The Corrupted Spirit of the Demons (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elgos Abbot.
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

[QuestScript(80092)]
public class Quest80092Script : QuestScript
{
	protected override void Load()
	{
		SetId(80092);
		SetName("The Corrupted Spirit of the Demons (1)");
		SetDescription("Talk to the Elgos Abbot");

		AddPrerequisite(new LevelPrerequisite(232));
		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_4_SQ_3"));

		AddObjective("kill0", "Kill 9 Brown Hohen Mane(s) or Green Hohen Orben(s) or Brown Harugal(s)", new KillObjective(9, 57968, 57976, 57980));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 8352));

		AddDialogHook("ABBEY_35_4_ELDER", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY_35_4_ELDER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ABBEY_35_4_SQ_4_start", "ABBEY_35_4_SQ_4", "I will try absorbing it", "It looks dangerous"))
		{
			case 1:
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

		await dialog.Msg("ABBEY_35_4_SQ_4_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

