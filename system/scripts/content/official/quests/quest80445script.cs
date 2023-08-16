//--- Melia Script -----------------------------------------------------------
// Goddess Austeja's Request (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Goddess Austeja.
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

[QuestScript(80445)]
public class Quest80445Script : QuestScript
{
	protected override void Load()
	{
		SetId(80445);
		SetName("Goddess Austeja's Request (1)");
		SetDescription("Talk to Goddess Austeja");

		AddPrerequisite(new CompletedPrerequisite("D_CASTLE_19_1_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(421));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("D_CASTLE_19_1_MQ_04_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("D_CASTLE_19_1_MQ_04_ST", "D_CASTLE_19_1_MQ_04"))
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
			await dialog.Msg("D_CASTLE_19_1_MQ_04_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

