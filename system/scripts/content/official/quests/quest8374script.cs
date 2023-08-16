//--- Melia Script -----------------------------------------------------------
// Requesting Support
//--- Description -----------------------------------------------------------
// Quest to Talk to Soldier Aspas.
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

[QuestScript(8374)]
public class Quest8374Script : QuestScript
{
	protected override void Load()
	{
		SetId(8374);
		SetName("Requesting Support");
		SetDescription("Talk to Soldier Aspas");
		SetTrack("SProgress", "ESuccess", "THORN22_ADD_SUB_05_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(121));

		AddObjective("kill0", "Kill 7 Wood Goblin(s)", new KillObjective(41290, 7));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3025));

		AddDialogHook("THORN22_ADD_SUB_05", "BeforeStart", BeforeStart);
		AddDialogHook("THORN22_ADD_SUB_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN22_ADD_SUB_05_select01", "THORN22_ADD_SUB_05", "I will protect you", "Stay hidden"))
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
			await dialog.Msg("THORN22_ADD_SUB_05_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

