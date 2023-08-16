//--- Melia Script -----------------------------------------------------------
// It's a Trap! Or Is It...?
//--- Description -----------------------------------------------------------
// Quest to Check the Trap.
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

[QuestScript(80215)]
public class Quest80215Script : QuestScript
{
	protected override void Load()
	{
		SetId(80215);
		SetName("It's a Trap! Or Is It...?");
		SetDescription("Check the Trap");
		SetTrack("SPossible", "ESuccess", "THORN39_2_SQ07_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("THORN39_2_SQ05"));
		AddPrerequisite(new LevelPrerequisite(173));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5190));

		AddDialogHook("THORN392_SQ07_OBJ1", "BeforeStart", BeforeStart);
		AddDialogHook("THORN392_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_2_SQ_07_select01", "THORN39_2_SQ07", "I'll get rid of it.", "I don't want to touch anything suspicious."))
			{
				case 1:
					dialog.HideNPC("THORN392_SQ07_OBJ1");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("THORN39_2_SQ_07_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

