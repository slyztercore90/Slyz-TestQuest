//--- Melia Script -----------------------------------------------------------
// Entrapped Goddess
//--- Description -----------------------------------------------------------
// Quest to Check the barrier at Saule Grand Shrine.
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

[QuestScript(18002)]
public class Quest18002Script : QuestScript
{
	protected override void Load()
	{
		SetId(18002);
		SetName("Entrapped Goddess");
		SetDescription("Check the barrier at Saule Grand Shrine");
		SetTrack("SProgress", "ESuccess", "HUEVILLAGE_58_4_MQ02_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ11"));
		AddPrerequisite(new LevelPrerequisite(55));

		AddObjective("kill0", "Kill 1 Harpeia", new KillObjective(47321, 1));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 32));
		AddReward(new ItemReward("Vis", 990));

		AddDialogHook("HUEVILLAGE_58_4_MQ01_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_4_SAULE_BEFORE", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("HUEVILLAGE_58_4_MQ02_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_4_MQ01");
	}
}

