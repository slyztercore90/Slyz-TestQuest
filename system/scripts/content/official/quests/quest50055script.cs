//--- Melia Script -----------------------------------------------------------
// Surrounded by Enemies
//--- Description -----------------------------------------------------------
// Quest to Move to Drill Ground of Confliction.
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

[QuestScript(50055)]
public class Quest50055Script : QuestScript
{
	protected override void Load()
	{
		SetId(50055);
		SetName("Surrounded by Enemies");
		SetDescription("Move to Drill Ground of Confliction");
		SetTrack("SProgress", "ESuccess", "UNDERFORTRESS_66_MQ010_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_65_MQ050"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddObjective("kill0", "Kill 5 Blue Ticen(s)", new KillObjective(57956, 5));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("AMANDA_66_1", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_DELLOOS01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDERFORTRESS_66_MQ010_startnpc01", "UNDERFORTRESS_66_MQ010", "Let's move", "I have something to do"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("UNDERFORTRESS_66_MQ010_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

