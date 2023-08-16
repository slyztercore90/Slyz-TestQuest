//--- Melia Script -----------------------------------------------------------
// Old Story (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Coben.
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

[QuestScript(8453)]
public class Quest8453Script : QuestScript
{
	protected override void Load()
	{
		SetId(8453);
		SetName("Old Story (2)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_01"));
		AddPrerequisite(new LevelPrerequisite(107));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_DRUNK_01", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS40_MQ_02_01", "REMAINS40_MQ_02", "I'll go and read the tombstone", "I'd like to stop"))
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
			await dialog.Msg("REMAINS40_MQ_02_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

