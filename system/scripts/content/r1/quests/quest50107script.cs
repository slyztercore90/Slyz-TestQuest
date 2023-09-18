//--- Melia Script -----------------------------------------------------------
// Demon Herbalist (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Herbalist Ash.
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

[QuestScript(50107)]
public class Quest50107Script : QuestScript
{
	protected override void Load()
	{
		SetId(50107);
		SetName("Demon Herbalist (3)");
		SetDescription("Talk to Herbalist Ash");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_2_SQ030"));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 448));

		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN632_PEAPLE01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("BRACKEN_63_2_SQ040_startnpc01", "BRACKEN_63_2_SQ040", "I'll help you spray the Loktanun Fluid", "Can we stop and go back now?"))
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


		return HookResult.Break;
	}
}

