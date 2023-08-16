//--- Melia Script -----------------------------------------------------------
// Evil Magic Circles? (4)
//--- Description -----------------------------------------------------------
// Quest to Search for more magic circles.
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

[QuestScript(80102)]
public class Quest80102Script : QuestScript
{
	protected override void Load()
	{
		SetId(80102);
		SetName("Evil Magic Circles? (4)");
		SetDescription("Search for more magic circles");
		SetTrack("SProgress", "ESuccess", "CORAL_35_2_SQ_4_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CORAL_35_2_SQ_3"));
		AddPrerequisite(new LevelPrerequisite(226));

		AddDialogHook("CORAL_35_2_LUTAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CORAL_35_2_SQ_4_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public override void OnStart(Character character, Quest quest)
	{
		var dialog = new Dialog(character, null);
		dialog.Msg("BalloonText/CORAL_35_2_SQ_4_start/15");
	}
}

