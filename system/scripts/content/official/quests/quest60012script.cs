//--- Melia Script -----------------------------------------------------------
// The Night Star
//--- Description -----------------------------------------------------------
// Quest to Meet Goddess Vakarine.
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

[QuestScript(60012)]
public class Quest60012Script : QuestScript
{
	protected override void Load()
	{
		SetId(60012);
		SetName("The Night Star");
		SetDescription("Meet Goddess Vakarine");
		SetTrack("SProgress", "ESuccess", "VPRISON514_MQ_01_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("VPRISON512_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(157));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));

		AddDialogHook("VPRISON514_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON514_MQ_VAKARINE", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("VPRISON514_MQ_01_03");
			// Func/VPRISON514_MQ_01_HAUBERK_01;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

