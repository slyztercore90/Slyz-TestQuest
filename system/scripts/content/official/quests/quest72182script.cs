//--- Melia Script -----------------------------------------------------------
// Investigate the First Control Room
//--- Description -----------------------------------------------------------
// Quest to Investigate the First Control Room.
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

[QuestScript(72182)]
public class Quest72182Script : QuestScript
{
	protected override void Load()
	{
		SetId(72182);
		SetName("Investigate the First Control Room");
		SetDescription("Investigate the First Control Room");
		SetTrack("SProgress", "ESuccess", "STARTOWER_89_MQ_20_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_89_MQ_10"));
		AddPrerequisite(new LevelPrerequisite(375));

		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("STARTOWER_89_MQ_20_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

