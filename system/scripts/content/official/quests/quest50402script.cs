//--- Melia Script -----------------------------------------------------------
// Hidden Research Archives
//--- Description -----------------------------------------------------------
// Quest to Talk to Wizard Nidia.
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

[QuestScript(50402)]
public class Quest50402Script : QuestScript
{
	protected override void Load()
	{
		SetId(50402);
		SetName("Hidden Research Archives");
		SetDescription("Talk to Wizard Nidia");

		AddPrerequisite(new CompletedPrerequisite("F_NICOPOLIS_81_3_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(387));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 1));
		AddReward(new ItemReward("Vis", 38000));

		AddDialogHook("NICO813_SUBQ_NPC2_2", "BeforeStart", BeforeStart);
		AddDialogHook("NICO813_SUBQ_NPC2_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("NICO813_SUBQ04_SUCC1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

