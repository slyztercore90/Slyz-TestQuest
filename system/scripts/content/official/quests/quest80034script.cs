//--- Melia Script -----------------------------------------------------------
// The Goddess' Assignment (1)
//--- Description -----------------------------------------------------------
// Quest to Find the Mysterious Girl.
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

[QuestScript(80034)]
public class Quest80034Script : QuestScript
{
	protected override void Load()
	{
		SetId(80034);
		SetName("The Goddess' Assignment (1)");
		SetDescription("Find the Mysterious Girl");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_342_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ORCHARD342_GIRL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.UnHideNPC("ORCHARD342_TRACE_04");
		dialog.UnHideNPC("ORCHARD342_TREE");
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ORCHARD_342_MQ_07");
	}
}

