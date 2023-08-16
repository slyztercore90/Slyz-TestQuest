//--- Melia Script -----------------------------------------------------------
// Sapper Master's Bomb Experiment [Sapper Advancement]
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sapper Submaster.
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

[QuestScript(30098)]
public class Quest30098Script : QuestScript
{
	protected override void Load()
	{
		SetId(30098);
		SetName("Sapper Master's Bomb Experiment [Sapper Advancement]");
		SetDescription("Talk to the Sapper Submaster");

		AddPrerequisite(new LevelPrerequisite(85));

		AddDialogHook("JOB_2_SAPPER_MASTER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_2_SAPPER_MASTER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_2_SAPPER_4_1_select", "JOB_2_SAPPER_4_1", "I'll help you", "Decline"))
			{
				case 1:
					await dialog.Msg("JOB_2_SAPPER_4_1_agree");
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
			if (character.Inventory.HasItem("JOB_2_SAPPER_4_1_ITEM", 50))
			{
				character.Inventory.RemoveItem("JOB_2_SAPPER_4_1_ITEM", 50);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("JOB_2_SAPPER_4_1_succ");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

