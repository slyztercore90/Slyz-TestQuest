//--- Melia Script -----------------------------------------------------------
// The Mysterious Girl (1)
//--- Description -----------------------------------------------------------
// Quest to Meeting the Mysterious Girl.
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

[QuestScript(80019)]
public class Quest80019Script : QuestScript
{
	protected override void Load()
	{
		SetId(80019);
		SetName("The Mysterious Girl (1)");
		SetDescription("Meeting the Mysterious Girl");
		SetTrack("SProgress", "ESuccess", "ORCHARD_323_MQ_02_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ORCHARD323_LEJA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

