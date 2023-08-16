//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (3)
//--- Description -----------------------------------------------------------
// Quest to Baiga wants you to meet him in the Second Hall.{nl}Go see Baiga in the Second Hall..
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

[QuestScript(80456)]
public class Quest80456Script : QuestScript
{
	protected override void Load()
	{
		SetId(80456);
		SetName("Root of the Divine Tree (3)");
		SetDescription("Baiga wants you to meet him in the Second Hall.{nl}Go see Baiga in the Second Hall.");
		SetTrack("SProgress", "ESuccess", "F_CASTLE_99_MQ_03_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_99_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(431));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));
		AddReward(new ItemReward("Vis", 24998));

		AddDialogHook("F_CASTLE_99_MQ_03_TRIGGER", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

