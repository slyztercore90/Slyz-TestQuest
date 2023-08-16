//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (4)
//--- Description -----------------------------------------------------------
// Quest to You could not find the Root of the Divine Tree.{nl}Go to Liudnas Lot to look for the root..
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

[QuestScript(80457)]
public class Quest80457Script : QuestScript
{
	protected override void Load()
	{
		SetId(80457);
		SetName("Root of the Divine Tree (4)");
		SetDescription("You could not find the Root of the Divine Tree.{nl}Go to Liudnas Lot to look for the root.");
		SetTrack("SPossible", "EPossible", "F_CASTLE_99_MQ_04_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(431));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("F_CASTLE_99_MQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_99_MQ_05_NPC", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("F_CASTLE_99_MQ_04_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

