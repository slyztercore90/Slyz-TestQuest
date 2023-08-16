//--- Melia Script -----------------------------------------------------------
// Secret of the Unusual Place
//--- Description -----------------------------------------------------------
// Quest to Hidden Area.
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

[QuestScript(19970)]
public class Quest19970Script : QuestScript
{
	protected override void Load()
	{
		SetId(19970);
		SetName("Secret of the Unusual Place");
		SetDescription("Hidden Area");
		SetTrack("SProgress", "ESuccess", "PILGRIM52_SQ_110_TRACK", "m_boss_d");

		AddPrerequisite(new LevelPrerequisite(133));

		AddObjective("kill0", "Kill 1 Velorchard", new KillObjective(57422, 1));

		AddReward(new ExpReward(542808, 542808));
		AddReward(new ItemReward("expCard7", 5));
		AddReward(new ItemReward("Vis", 3325));

		AddDialogHook("PILGRIM52_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_BOX", "BeforeEnd", BeforeEnd);
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
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("NPCAin/PILGRIM52_BOX/OPENSTD/0");
			await Task.Delay(2000);
			dialog.HideNPC("PILGRIM52_BOX");
			await dialog.Msg("FadeOutIN/2000");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

