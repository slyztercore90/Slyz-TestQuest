//--- Melia Script -----------------------------------------------------------
// Statue of Peace (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Dievdirbys Widas.
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

[QuestScript(80028)]
public class Quest80028Script : QuestScript
{
	protected override void Load()
	{
		SetId(80028);
		SetName("Statue of Peace (2)");
		SetDescription("Talk to Dievdirbys Widas");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1840));
		AddReward(new ItemReward("Drug_SP2_Q", 25));

		AddDialogHook("ORCHARD323_VYDAS", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_VYDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_323_SQ_05_start", "ORCHARD_323_SQ_05", "I'll go now", "I don't have time for that"))
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

