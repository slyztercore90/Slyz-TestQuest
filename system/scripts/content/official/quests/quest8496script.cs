//--- Melia Script -----------------------------------------------------------
// Destroy the 4th Magic Suppressor
//--- Description -----------------------------------------------------------
// Quest to Destroy Helgasercle's 4th Magic Suppressor.
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

[QuestScript(8496)]
public class Quest8496Script : QuestScript
{
	protected override void Load()
	{
		SetId(8496);
		SetName("Destroy the 4th Magic Suppressor");
		SetDescription("Destroy Helgasercle's 4th Magic Suppressor");
		SetTrack("SProgress", "ESuccess", "FTOWER45_MQ_04_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("FTOWER45_MQ_PRO"));
		AddPrerequisite(new LevelPrerequisite(126));

		AddObjective("kill0", "Kill 1 Magic Suppressor", new KillObjective(151003, 1));

		AddReward(new ExpReward(690268, 690268));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 6));
		AddReward(new ItemReward("Vis", 3150));

		AddDialogHook("FTOWER45_MQ_04_D", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}
}

