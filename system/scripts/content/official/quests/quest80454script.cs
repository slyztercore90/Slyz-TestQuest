//--- Melia Script -----------------------------------------------------------
// Root of the Divine Tree (1)
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

[QuestScript(80454)]
public class Quest80454Script : QuestScript
{
	protected override void Load()
	{
		SetId(80454);
		SetName("Root of the Divine Tree (1)");
		SetDescription("Talk to Goddess Austeja");

		AddPrerequisite(new CompletedPrerequisite("F_CASTLE_97_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(431));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 16));

		AddDialogHook("F_CASTLE_99_MQ_01_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_CASTLE_99_MQ_01_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_CASTLE_99_MQ_01_ST", "F_CASTLE_99_MQ_01", "Say that you are worried about Goddess Medeina.", "Say it's too late."))
			{
				case 1:
					// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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
			await dialog.Msg("F_CASTLE_99_MQ_01_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

