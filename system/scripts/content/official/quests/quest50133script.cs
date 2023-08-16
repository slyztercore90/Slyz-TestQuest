//--- Melia Script -----------------------------------------------------------
// A Monk's Last Mission (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Monk Abels.
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

[QuestScript(50133)]
public class Quest50133Script : QuestScript
{
	protected override void Load()
	{
		SetId(50133);
		SetName("A Monk's Last Mission (2)");
		SetDescription("Talk to Monk Abels");

		AddPrerequisite(new CompletedPrerequisite("ABBAY_64_2_SQ040"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(75978, 75978));
		AddReward(new ItemReward("expCard3", 5));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("ABBEY642_MONK01", "BeforeStart", BeforeStart);
		AddDialogHook("ABBEY642_MONK01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ABBAY_64_2_SQ050_startnpc01", "ABBAY_64_2_SQ050", "I will come back soon", "Just give me some time"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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

