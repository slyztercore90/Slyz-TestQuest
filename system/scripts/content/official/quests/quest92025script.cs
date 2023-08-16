//--- Melia Script -----------------------------------------------------------
// Divide and rule (5)
//--- Description -----------------------------------------------------------
// Quest to Look around the Mirtinas Storage.
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

[QuestScript(92025)]
public class Quest92025Script : QuestScript
{
	protected override void Load()
	{
		SetId(92025);
		SetName("Divide and rule (5)");
		SetDescription("Look around the Mirtinas Storage");
		SetTrack("SProgress", "ESuccess", "EP13_F_SIAULIAI_4_MQ08_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_4_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(456));

		AddObjective("kill0", "Kill 1 Saugumas Executor", new KillObjective(59596, 1));

		AddReward(new ItemReward("expCard18", 11));
		AddReward(new ItemReward("Vis", 28272));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 33));

		AddDialogHook("EP13_F_SIAULIAI_MQ08_BOX", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_MQ08_BOX", "BeforeEnd", BeforeEnd);
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
			dialog.UnHideNPC("EP13_F_SIAULIAI_4_BOMB");
			// Func/SCR_EP13_F_SIAULIAI_4_MQ08_GUIDE2;
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			// Func/SCR_NEXTQUEST_LEVEL_CHECK/EP13_F_SIAULIAI_5_MQ_01_RE;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

