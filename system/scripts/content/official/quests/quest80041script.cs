//--- Melia Script -----------------------------------------------------------
// Divine Encounter 
//--- Description -----------------------------------------------------------
// Quest to Look for Goddess Lada.
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

[QuestScript(80041)]
public class Quest80041Script : QuestScript
{
	protected override void Load()
	{
		SetId(80041);
		SetName("Divine Encounter ");
		SetDescription("Look for Goddess Lada");
		SetTrack("SProgress", "ESuccess", "ORCHARD_324_MQ_01_TRACK", "m_boss_scenario2");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_08"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ORCHARD324_LADA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		// Func/ORCHARD324_BINDIG_UNHIDE;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_324_MQ_02");
	}
}

