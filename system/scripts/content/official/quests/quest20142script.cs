//--- Melia Script -----------------------------------------------------------
// Strange Stone
//--- Description -----------------------------------------------------------
// Quest to Talk to Liaison Officer Nian.
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

[QuestScript(20142)]
public class Quest20142Script : QuestScript
{
	protected override void Load()
	{
		SetId(20142);
		SetName("Strange Stone");
		SetDescription("Talk to Liaison Officer Nian");
		SetTrack("SProgress", "ESuccess", "ROKAS28_MQ1_TRACK", 4000);

		AddPrerequisite(new LevelPrerequisite(69));

		AddObjective("kill0", "Kill 18 Lauzinute(s) or Hogma Archer(s)", new KillObjective(18, 47328, 41434));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1311));

		AddDialogHook("ROKAS28_MQ1_1", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS28_MQ1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS28_MQ1_01", "ROKAS28_MQ1", "Touch the stone to look closely", "Just go"))
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
			await dialog.Msg("ROKAS28_MQ1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

