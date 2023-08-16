//--- Melia Script -----------------------------------------------------------
// The Flower Enriched With the Earth
//--- Description -----------------------------------------------------------
// Quest to Talk with the Village Great Priest.
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

[QuestScript(80051)]
public class Quest80051Script : QuestScript
{
	protected override void Load()
	{
		SetId(80051);
		SetName("The Flower Enriched With the Earth");
		SetDescription("Talk with the Village Great Priest");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_FUZE", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_LADA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_324_SQ_04_start", "ORCHARD_324_SQ_04", "I will try", "I can't help you"))
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

