//--- Melia Script -----------------------------------------------------------
// Missing Researcher (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Airine.
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

[QuestScript(4420)]
public class Quest4420Script : QuestScript
{
	protected override void Load()
	{
		SetId(4420);
		SetName("Missing Researcher (4)");
		SetDescription("Talk to Airine");
		SetTrack("SProgress", "ESuccess", "ROKAS27_QB_15_TRACK", 4000);

		AddPrerequisite(new CompletedPrerequisite("ROKAS27_QB_5"));
		AddPrerequisite(new LevelPrerequisite(67));

		AddReward(new ExpReward(68580, 68580));
		AddReward(new ItemReward("expCard5", 3));
		AddReward(new ItemReward("Vis", 1273));

		AddDialogHook("ROKAS27_AIRINE", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS27_AIRINE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS27_QB_8_select1", "ROKAS27_QB_8", "Prepare to protect Airine", "Run away"))
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
			await dialog.Msg("ROKAS27_QB_8_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

