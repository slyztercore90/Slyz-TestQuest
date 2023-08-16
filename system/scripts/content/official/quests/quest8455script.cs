//--- Melia Script -----------------------------------------------------------
// Old Story (4)
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

[QuestScript(8455)]
public class Quest8455Script : QuestScript
{
	protected override void Load()
	{
		SetId(8455);
		SetName("Old Story (4)");
		SetDescription("Talk to Coben");

		AddPrerequisite(new CompletedPrerequisite("REMAINS40_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(107));

		AddReward(new ExpReward(122855, 122855));
		AddReward(new ItemReward("expCard6", 1));
		AddReward(new ItemReward("Vis", 2568));

		AddDialogHook("REMAINS_40_DRUNK_02", "BeforeStart", BeforeStart);
		AddDialogHook("REMAINS_40_DRUNK_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("REMAINS40_MQ_04_01", "REMAINS40_MQ_04", "Read the tombstone and come back", "Decline"))
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
			await dialog.Msg("REMAINS40_MQ_04_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

