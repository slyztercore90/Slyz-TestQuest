//--- Melia Script -----------------------------------------------------------
// Hauberk in the Maze (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Daiva.
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

[QuestScript(60020)]
public class Quest60020Script : QuestScript
{
	protected override void Load()
	{
		SetId(60020);
		SetName("Hauberk in the Maze (3)");
		SetDescription("Talk to Kupole Daiva");

		AddPrerequisite(new CompletedPrerequisite("VPRISON513_MQ_02"));
		AddPrerequisite(new LevelPrerequisite(160));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 4800));

		AddDialogHook("VPRISON513_MQ_DAIVA_02", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_DAIVA_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("VPRISON513_MQ_03_01", "VPRISON513_MQ_03", "I will chase after Hauberk", "I'm not sure if I can take down all those demons"))
			{
				case 1:
					await dialog.Msg("VPRISON513_MQ_03_AG");
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
			await dialog.Msg("VPRISON513_MQ_03_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

