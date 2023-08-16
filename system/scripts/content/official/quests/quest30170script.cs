//--- Melia Script -----------------------------------------------------------
// Through the front door
//--- Description -----------------------------------------------------------
// Quest to Disarm Grinende's Magic Circle.
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

[QuestScript(30170)]
public class Quest30170Script : QuestScript
{
	protected override void Load()
	{
		SetId(30170);
		SetName("Through the front door");
		SetDescription("Disarm Grinende's Magic Circle");
		SetTrack("SProgress", "ESuccess", "PRISON_80_MQ_7_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("PRISON_80_MQ_6"));
		AddPrerequisite(new LevelPrerequisite(265));
		AddPrerequisite(new ItemPrerequisite("PRISON_80_MQ_3_ITEM", -100));

		AddObjective("kill0", "Kill 1 Grinender", new KillObjective(58432, 1));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 10865));

		AddDialogHook("PRISON_80_OBJ_4", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_80_NPC_2", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("PRISON_80_MQ_7_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

