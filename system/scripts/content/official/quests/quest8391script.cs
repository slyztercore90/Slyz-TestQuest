//--- Melia Script -----------------------------------------------------------
// The Guardian's Jar (4)
//--- Description -----------------------------------------------------------
// Quest to Give the pot to the Secret Guardian.
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

[QuestScript(8391)]
public class Quest8391Script : QuestScript
{
	protected override void Load()
	{
		SetId(8391);
		SetName("The Guardian's Jar (4)");
		SetDescription("Give the pot to the Secret Guardian");
		SetTrack("SProgress", "ESuccess", "ZACHA5F_MQ_04_TRACK", "m_boss_scenario");

		AddPrerequisite(new CompletedPrerequisite("ZACHA5F_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(94));

		AddReward(new ExpReward(640130, 640130));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 100));
		AddReward(new ItemReward("Vis", 1880));

		AddDialogHook("ZACHA5F_MQ_04", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

