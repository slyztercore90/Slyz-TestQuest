//--- Melia Script -----------------------------------------------------------
// Ardor for Study (3)
//--- Description -----------------------------------------------------------
// Quest to Place the amulet on the stone pillar.
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

[QuestScript(9022)]
public class Quest9022Script : QuestScript
{
	protected override void Load()
	{
		SetId(9022);
		SetName("Ardor for Study (3)");
		SetDescription("Place the amulet on the stone pillar");
		SetTrack("SProgress", "ESuccess", "ROKAS28_EXPOSURE_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS28_ENTICE"));
		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("kill0", "Kill 7 Lauzinute(s) or Hogma Archer(s)", new KillObjective(7, 47328, 41434));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_ENTICE", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_FRIDKA", "BeforeEnd", BeforeEnd);
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
			await dialog.Msg("ROKAS28_EXPOSURE_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ROKAS28_MQ5");
	}
}

