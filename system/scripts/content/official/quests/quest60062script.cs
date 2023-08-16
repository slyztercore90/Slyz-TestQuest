//--- Melia Script -----------------------------------------------------------
// The Legwyn Family's Tragedy (1)
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

[QuestScript(60062)]
public class Quest60062Script : QuestScript
{
	protected override void Load()
	{
		SetId(60062);
		SetName("The Legwyn Family's Tragedy (1)");
		SetDescription("Talk to the spirit of Gailus Legwyn");

		AddPrerequisite(new CompletedPrerequisite("PILGRIM313_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 9 Corrupt Fangs(s)", new CollectItemObjective("PILGRIM313_SQ_05_ITEM", 9));
		AddDrop("PILGRIM313_SQ_05_ITEM", 8f, 58134, 58135, 58136);

		AddReward(new ExpReward(205740, 205740));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 1700));

		AddDialogHook("PILGRIM313_GALIUS", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM313_GALIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM313_SQ_05_01", "PILGRIM313_SQ_05", "Tell him that you will collect Corrupt Fangs", "I'll wait a little bit"))
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

