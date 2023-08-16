//--- Melia Script -----------------------------------------------------------
// The Shaman Doll and the Savior
//--- Description -----------------------------------------------------------
// Quest to Talk to Revelator Yane.
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

[QuestScript(70444)]
public class Quest70444Script : QuestScript
{
	protected override void Load()
	{
		SetId(70444);
		SetName("The Shaman Doll and the Savior");
		SetDescription("Talk to Revelator Yane");
		SetTrack("SSuccess", "ESuccess", "CASTLE65_3_MQ05_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_3_MQ04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(245710, 245710));
		AddReward(new ItemReward("expCard5", 2));
		AddReward(new ItemReward("Vis", 1680));

		AddDialogHook("CASTLE653_MQ_05_1", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE653_MQ_05_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE653_MQ_05_start", "CASTLE65_3_MQ05", "I will come back soon", "That sounds dangerous"))
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

