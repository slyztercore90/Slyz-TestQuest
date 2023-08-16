//--- Melia Script -----------------------------------------------------------
// Attack of Biteregina
//--- Description -----------------------------------------------------------
// Quest to Attack of Biteregina.
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

[QuestScript(8339)]
public class Quest8339Script : QuestScript
{
	protected override void Load()
	{
		SetId(8339);
		SetName("Attack of Biteregina");
		SetDescription("Attack of Biteregina");
		SetTrack("SProgress", "ESuccess", "KATYN18_SUB03_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Biteregina", new KillObjective(57086, 1));

		AddDialogHook("KATYN18_SUB_03", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_SUB_03", "BeforeEnd", BeforeEnd);
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

