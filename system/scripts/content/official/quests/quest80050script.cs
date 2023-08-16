//--- Melia Script -----------------------------------------------------------
// Temple Rebuilding Preparation (3)
//--- Description -----------------------------------------------------------
// Quest to Speak with the Village Priest.
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

[QuestScript(80050)]
public class Quest80050Script : QuestScript
{
	protected override void Load()
	{
		SetId(80050);
		SetName("Temple Rebuilding Preparation (3)");
		SetDescription("Speak with the Village Priest");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_SQ_02"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_324_SQ_03_start", "ORCHARD_324_SQ_03", "I will be the one to purify", "I can only help so much"))
			{
				case 1:
					await dialog.Msg("ORCHARD_324_SQ_03_AG");
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

