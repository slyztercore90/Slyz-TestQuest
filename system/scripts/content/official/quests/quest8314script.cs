//--- Melia Script -----------------------------------------------------------
// Spiritual Poison (4)
//--- Description -----------------------------------------------------------
// Quest to Defeat the surging monsters.
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

[QuestScript(8314)]
public class Quest8314Script : QuestScript
{
	protected override void Load()
	{
		SetId(8314);
		SetName("Spiritual Poison (4)");
		SetDescription("Defeat the surging monsters");
		SetTrack("SProgress", "ESuccess", "KATYN18_MQ_08_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 8 Red Puragi(s)", new KillObjective(400304, 8));

		AddDialogHook("KATYN18_OWL_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_OWL_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		return HookResult.Continue;
	}
}

