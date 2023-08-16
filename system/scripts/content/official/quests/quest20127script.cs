//--- Melia Script -----------------------------------------------------------
// Using Status Points
//--- Description -----------------------------------------------------------
// Quest to Talk to the Scout.
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

[QuestScript(20127)]
public class Quest20127Script : QuestScript
{
	protected override void Load()
	{
		SetId(20127);
		SetName("Using Status Points");
		SetDescription("Talk to the Scout");

		AddPrerequisite(new CompletedPrerequisite("SIAUL_WEST_DRASIUS1"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeStart", BeforeStart);
		AddDialogHook("SIALUL_WEST_DRASIUS", "BeforeEnd", BeforeEnd);
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

