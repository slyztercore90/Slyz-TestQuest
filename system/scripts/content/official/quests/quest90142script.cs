//--- Melia Script -----------------------------------------------------------
// Trace Race (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90142)]
public class Quest90142Script : QuestScript
{
	protected override void Load()
	{
		SetId(90142);
		SetName("Trace Race (2)");
		SetDescription("Talk with Kupole Leda");
		SetTrack("SProgress", "ESuccess", "F_DCAPITAL_20_6_SQ_30_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_25"));
		AddPrerequisite(new LevelPrerequisite(295));

		AddObjective("kill0", "Kill 1 Riteris", new KillObjective(107011, 1));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_DCAPITAL_20_6_SQ_30_ST", "F_DCAPITAL_20_6_SQ_30", "I will be right there immediately.", "Need some more time."))
			{
				case 1:
					await dialog.Msg("F_DCAPITAL_20_6_SQ_30_AG");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

