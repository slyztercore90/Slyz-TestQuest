//--- Melia Script -----------------------------------------------------------
// Temple Rebuilding Preparation (1)
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

[QuestScript(80048)]
public class Quest80048Script : QuestScript
{
	protected override void Load()
	{
		SetId(80048);
		SetName("Temple Rebuilding Preparation (1)");
		SetDescription("Speak with the Village Priest");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_324_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 12 Vikaras Mage(s)", new KillObjective(58158, 12));

		AddReward(new ExpReward(147426, 147426));
		AddReward(new ItemReward("expCard6", 4));
		AddReward(new ItemReward("Vis", 2400));

		AddDialogHook("ORCHARD324_PRIEST", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD324_PRIEST", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_324_SQ_01_start", "ORCHARD_324_SQ_01", "Alright, I'll help you", "I don't have time for that"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_324_SQ_02");
	}
}

