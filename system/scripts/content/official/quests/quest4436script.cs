//--- Melia Script -----------------------------------------------------------
// Gorath's Concern (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Gorath.
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

[QuestScript(4436)]
public class Quest4436Script : QuestScript
{
	protected override void Load()
	{
		SetId(4436);
		SetName("Gorath's Concern (3)");
		SetDescription("Talk to Gorath");
		SetTrack("SProgress", "ESuccess", "ROKAS24_QB_9_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("ROKAS24_SQ_03"));
		AddPrerequisite(new LevelPrerequisite(58));

		AddObjective("kill0", "Kill 1 Molich", new KillObjective(57076, 1));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 1044));

		AddDialogHook("ROKAS_24_GORATH", "BeforeStart", BeforeStart);
		AddDialogHook("ROKAS_24_GORATH", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ROKAS24_QB_9_ST", "ROKAS24_QB_9", "Tell him that Molich wasn't there", "Ignore since you are scared"))
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

		return HookResult.Continue;
	}
}

