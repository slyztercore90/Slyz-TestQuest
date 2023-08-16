//--- Melia Script -----------------------------------------------------------
// Activate the Auka Altar
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Algis.
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

[QuestScript(8533)]
public class Quest8533Script : QuestScript
{
	protected override void Load()
	{
		SetId(8533);
		SetName("Activate the Auka Altar");
		SetDescription("Talk to Follower Algis");

		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(48));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 720));

		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE577_MQ_06_01", "CHAPLE577_MQ_06", "No problem", "I'll think about it for a while"))
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
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("CHAPLE577_MQ_06_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

