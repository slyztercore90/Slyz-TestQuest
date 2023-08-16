//--- Melia Script -----------------------------------------------------------
// To trap a beast(1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Vilhelmas.
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

[QuestScript(70808)]
public class Quest70808Script : QuestScript
{
	protected override void Load()
	{
		SetId(70808);
		SetName("To trap a beast(1)");
		SetDescription("Talk to Vilhelmas");

		AddPrerequisite(new CompletedPrerequisite("WHITETREES23_1_SQ08"));
		AddPrerequisite(new LevelPrerequisite(316));

		AddReward(new ExpReward(18151784, 18151784));
		AddReward(new ItemReward("expCard14", 1));
		AddReward(new ItemReward("Vis", 14536));

		AddDialogHook("WHITETREES231_SQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("WHITETREES231_SQ_09_start", "WHITETREES23_1_SQ09", "Leave it to me", "I'm not ready yet"))
			{
				case 1:
					await dialog.Msg("WHITETREES231_SQ_09_agree");
					character.Quests.Start(this.QuestId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("WHITETREES23_1_SQ10");
	}
}

