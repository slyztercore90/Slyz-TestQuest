//--- Melia Script -----------------------------------------------------------
// [Repetition] Salvation - Legend Raid
//--- Description -----------------------------------------------------------
// Quest to Clear Legend Raid 50 times.
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

[QuestScript(530002)]
public class Quest530002Script : QuestScript
{
	protected override void Load()
	{
		SetId(530002);
		SetName("[Repetition] Salvation - Legend Raid");
		SetDescription("Clear Legend Raid 50 times");

		AddPrerequisite(new CompletedPrerequisite("REPUTATION_OPEN_QUEST"), new CompletedPrerequisite("P_R_EP13_1"), new CompletedPrerequisite("P_R_EP13_3"));
		AddPrerequisite(new LevelPrerequisite(458));

		AddReward(new ItemReward("reputation_Coin", 20000));

		AddDialogHook("EP13_WEEK_REPUTATION_01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

