//--- Melia Script -----------------------------------------------------------
// Root of Tankinta Vacant Lot
//--- Description -----------------------------------------------------------
// Quest to Check Tankinta Vacant Lot.
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

[QuestScript(20272)]
public class Quest20272Script : QuestScript
{
	protected override void Load()
	{
		SetId(20272);
		SetName("Root of Tankinta Vacant Lot");
		SetDescription("Check Tankinta Vacant Lot");
		SetTrack("SProgress", "ESuccess", "THORN21_MQ05_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("THORN21_MQ09"));
		AddPrerequisite(new LevelPrerequisite(64));

		AddObjective("kill0", "Kill 1 Molich", new KillObjective(400421, 1));
		AddObjective("kill1", "Kill 1 Bramble's Root", new KillObjective(153011, 1));

		AddReward(new ExpReward(118188, 118188));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 1216));

		AddDialogHook("THORN21_BRAMBLE02_ROOT", "BeforeStart", BeforeStart);
		AddDialogHook("THORN21_BELIEVER04", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("THORN21_MQ05_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

