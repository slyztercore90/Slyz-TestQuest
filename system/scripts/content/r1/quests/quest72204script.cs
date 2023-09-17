//--- Melia Script -----------------------------------------------------------
// Building Initiation (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Commander Byle.
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

[QuestScript(72204)]
public class Quest72204Script : QuestScript
{
	protected override void Load()
	{
		SetId(72204);
		SetName("Building Initiation (6)");
		SetDescription("Talk to Resistance Commander Byle");
		SetTrack(QuestStatus.Progress, QuestStatus.Success, "STARTOWER_91_MQ_60_TRACK", "None");

		AddPrerequisite(new LevelPrerequisite(382));
		AddPrerequisite(new CompletedPrerequisite("STARTOWER_91_MQ_50"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 4));

		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_01", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_91_RESISTANCE_LEADER_BAYL_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("STARTOWER_91_MQ_60_DLG1", "STARTOWER_91_MQ_60", "Alright", "I need to rest."))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				character.Tracks.Start(this.TrackData);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("STARTOWER_91_MQ_60_DLG3");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

