//--- Melia Script -----------------------------------------------------------
// The King of the Great Humans
//--- Description -----------------------------------------------------------
// Quest to Go to the burial chamber of the Royal Mausoleum.
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

[QuestScript(8392)]
public class Quest8392Script : QuestScript
{
	protected override void Load()
	{
		SetId(8392);
		SetName("The King of the Great Humans");
		SetDescription("Go to the burial chamber of the Royal Mausoleum");
		SetTrack("SProgress", "ESuccess", "ZACHA5_SPIRIT_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ZACHA5F_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(94));

		AddReward(new ExpReward(640152, 640152));
		AddReward(new ItemReward("Vis", 18800));
		AddReward(new ItemReward("stonetablet04", 1));
		AddReward(new ItemReward("COLLECT_117", 1));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier1", 138));

		AddDialogHook("ZACHA5F_MQ_05", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

