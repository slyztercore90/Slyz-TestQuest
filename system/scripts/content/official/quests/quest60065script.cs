//--- Melia Script -----------------------------------------------------------
// The Journey to Find Myself (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Demon Lord Hauberk.
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

[QuestScript(60065)]
public class Quest60065Script : QuestScript
{
	protected override void Load()
	{
		SetId(60065);
		SetName("The Journey to Find Myself (5)");
		SetDescription("Talk to Demon Lord Hauberk");
		SetTrack("SProgress", "ESuccess", "PILGRIM312_SQ_05_AFTER", 4000);

		AddPrerequisite(new CompletedPrerequisite("PILGRIM312_SQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("PILGRIM312_HAUBERK_03", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM312_HAUBERK_03", "BeforeEnd", BeforeEnd);
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

