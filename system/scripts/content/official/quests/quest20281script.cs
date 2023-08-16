//--- Melia Script -----------------------------------------------------------
// Ominous Energy at Ershike Altar
//--- Description -----------------------------------------------------------
// Quest to Check the Ershike Altar.
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

[QuestScript(20281)]
public class Quest20281Script : QuestScript
{
	protected override void Load()
	{
		SetId(20281);
		SetName("Ominous Energy at Ershike Altar");
		SetDescription("Check the Ershike Altar");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_2_MQ03"));
		AddPrerequisite(new LevelPrerequisite(49));

		AddReward(new ExpReward(118118, 118118));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 31));
		AddReward(new ItemReward("Vis", 735));

		AddDialogHook("HUEVILLAGE_58_2_MQ03_NPC", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

