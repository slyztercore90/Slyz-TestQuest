//--- Melia Script -----------------------------------------------------------
// Dangerous Distraction
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Mihail.
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

[QuestScript(60177)]
public class Quest60177Script : QuestScript
{
	protected override void Load()
	{
		SetId(60177);
		SetName("Dangerous Distraction");
		SetDescription("Talk to Revelator Mihail");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ09"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 12 Pag Emitter(s)", new KillObjective(58077, 12));

		AddReward(new ExpReward(49142, 49142));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_04_2", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_04_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE653_RP_1_1", "CASTLE653_RP_1", "I will defeat it", "Ignore"))
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

