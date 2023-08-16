//--- Melia Script -----------------------------------------------------------
// Purify the Holy Pond
//--- Description -----------------------------------------------------------
// Quest to Purify the Holy Pond.
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

[QuestScript(18110)]
public class Quest18110Script : QuestScript
{
	protected override void Load()
	{
		SetId(18110);
		SetName("Purify the Holy Pond");
		SetDescription("Purify the Holy Pond");
		SetTrack("SProgress", "ESuccess", "HUEVILLAGE_58_1_MQ02_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("HUEVILLAGE_58_1_MQ01"));
		AddPrerequisite(new LevelPrerequisite(36));

		AddReward(new ExpReward(151956, 151956));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 62));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("HUEVILLAGE_58_1_MQ02_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("HUEVILLAGE_58_1_MQ01_NPC", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("HUEVILLAGE_58_1_MQ02_succ");
			dialog.UnHideNPC("HUEVILLAGE_58_1_MQ03_NPC");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("HUEVILLAGE_58_1_MQ03");
	}
}

