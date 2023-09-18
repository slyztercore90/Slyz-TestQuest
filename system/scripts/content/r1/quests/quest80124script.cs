//--- Melia Script -----------------------------------------------------------
// Brainwashed Tribe (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Trija.
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

[QuestScript(80124)]
public class Quest80124Script : QuestScript
{
	protected override void Load()
	{
		SetId(80124);
		SetName("Brainwashed Tribe (2)");
		SetDescription("Talk to Kupole Trija");

		AddPrerequisite(new LevelPrerequisite(287));
		AddPrerequisite(new CompletedPrerequisite("LIMESTONE_52_1_SQ_1"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12054));

		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeStart", BeforeStart);
		AddDialogHook("LIMESTONECAVE_52_1_TRIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("LIMESTONE_52_1_SQ_2_start", "LIMESTONE_52_1_SQ_2", "I'll purify it", "That will be useless."))
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

		await dialog.Msg("LIMESTONE_52_1_SQ_2_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

