//--- Melia Script -----------------------------------------------------------
// Good Use For a Wand (1)
//--- Description -----------------------------------------------------------
// Quest to Check the Suspicious Wand Fragment.
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

[QuestScript(80201)]
public class Quest80201Script : QuestScript
{
	protected override void Load()
	{
		SetId(80201);
		SetName("Good Use For a Wand (1)");
		SetDescription("Check the Suspicious Wand Fragment");
		SetTrack("SPossible", "ESuccess", "CHATHEDRAL53_SQ07_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(137));

		AddObjective("kill0", "Kill 12 Darkness Anchor(s)", new KillObjective(57678, 12));

		AddReward(new ExpReward(426450, 426450));
		AddReward(new ItemReward("expCard8", 3));
		AddReward(new ItemReward("Vis", 3425));

		AddDialogHook("CHATHEDRAL53_SQ07_OBJ1", "BeforeStart", BeforeStart);
		AddDialogHook("CHATHEDRAL53_SQ03", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("CHATHEDRAL53_SQ07_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

