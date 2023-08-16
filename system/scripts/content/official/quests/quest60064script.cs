//--- Melia Script -----------------------------------------------------------
// The Legwyn Family's Tragedy (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the spirit of Gailus Legwyn.
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

[QuestScript(60064)]
public class Quest60064Script : QuestScript
{
	protected override void Load()
	{
		SetId(60064);
		SetName("The Legwyn Family's Tragedy (3)");
		SetDescription("Talk to the spirit of Gailus Legwyn");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM313_SQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(137160, 137160));
		AddReward(new ItemReward("expCard5", 4));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("PILGRIM313_GALIUS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM313_WILLIYA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM313_SQ_07_01", "PILGRIM313_SQ_07", "I will do that", "I'll wait a little bit"))
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

