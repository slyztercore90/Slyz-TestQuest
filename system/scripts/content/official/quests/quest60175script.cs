//--- Melia Script -----------------------------------------------------------
// Efforts Towards Redemption
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Bigs.
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

[QuestScript(60175)]
public class Quest60175Script : QuestScript
{
	protected override void Load()
	{
		SetId(60175);
		SetName("Efforts Towards Redemption");
		SetDescription("Talk to Follower Bigs");

		AddPrerequisite(new CompletedPrerequisite("CASTLE65_2_MQ05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("collect0", "Collect 12 Concentrated Evil Energy(s)", new CollectItemObjective("CASTLE652_RP_2_ITEM", 12));
		AddDrop("CASTLE652_RP_2_ITEM", 0.8f, 58079, 58075, 58073, 58110);

		AddReward(new ExpReward(24571, 24571));
		AddReward(new ItemReward("expCard5", 1));
		AddReward(new ItemReward("Vis", 1600));

		AddDialogHook("CASTLE652_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("CASTLE652_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CASTLE652_RP_2_1", "CASTLE652_RP_2", "I'll help you", "Decline"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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

