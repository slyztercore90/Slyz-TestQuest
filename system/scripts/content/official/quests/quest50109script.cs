//--- Melia Script -----------------------------------------------------------
// Giant Bracken (2)
//--- Description -----------------------------------------------------------
// Quest to Search for materials on the Giant Bracken.
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

[QuestScript(50109)]
public class Quest50109Script : QuestScript
{
	protected override void Load()
	{
		SetId(50109);
		SetName("Giant Bracken (2)");
		SetDescription("Search for materials on the Giant Bracken");

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_MQ010"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(84420, 84420));
		AddReward(new ItemReward("expCard3", 2));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_ROZE01", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

