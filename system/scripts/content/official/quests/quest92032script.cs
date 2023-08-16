//--- Melia Script -----------------------------------------------------------
// Extinct Mirtinas (5)
//--- Description -----------------------------------------------------------
// Quest to Talk with Inesa Hamondale.
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

[QuestScript(92032)]
public class Quest92032Script : QuestScript
{
	protected override void Load()
	{
		SetId(92032);
		SetName("Extinct Mirtinas (5)");
		SetDescription("Talk with Inesa Hamondale");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_5_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(458));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_GODDESS_LADA4TO5", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP13_F_SIAULIAI_5_MQ_06_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP13_F_SIAULIAI_5_MQ_07");
	}
}

