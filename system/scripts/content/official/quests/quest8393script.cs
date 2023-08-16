//--- Melia Script -----------------------------------------------------------
// Holy Offering's Delivery [Krivis Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to Krivis Brother.
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

[QuestScript(8393)]
public class Quest8393Script : QuestScript
{
	protected override void Load()
	{
		SetId(8393);
		SetName("Holy Offering's Delivery [Krivis Advancement]");
		SetDescription("Talk to Krivis Brother");

		AddPrerequisite(new CompletedPrerequisite("JOB_KRIWI1"));
		AddPrerequisite(new LevelPrerequisite(15));

		AddDialogHook("JOB_KRIWI1_OUT", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_KRIWI", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_KRIWI1_1_01", "JOB_KRIWI1_1"))
			{
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
			await dialog.Msg("JOB_KRIWI1_1_02");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

