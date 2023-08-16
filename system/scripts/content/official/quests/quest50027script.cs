//--- Melia Script -----------------------------------------------------------
// To Demon Prison District 1
//--- Description -----------------------------------------------------------
// Quest to Move to Demon Prison District 1.
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

[QuestScript(50027)]
public class Quest50027Script : QuestScript
{
	protected override void Load()
	{
		SetId(50027);
		SetName("To Demon Prison District 1");
		SetDescription("Move to Demon Prison District 1");

		AddPrerequisite(new CompletedPrerequisite("CHATHEDRAL54_MQ06_PART3"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MQ05_PROOF_PRIST", "BeforeStart", BeforeStart);
		AddDialogHook("FARM_47_2_TO_VELNIASP511", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

