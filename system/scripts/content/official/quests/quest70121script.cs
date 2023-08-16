//--- Melia Script -----------------------------------------------------------
// Everyone Ready?
//--- Description -----------------------------------------------------------
// Quest to Talk to Senior Monk Marko.
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

[QuestScript(70121)]
public class Quest70121Script : QuestScript
{
	protected override void Load()
	{
		SetId(70121);
		SetName("Everyone Ready?");
		SetDescription("Talk to Senior Monk Marko");

		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ01"));
		AddPrerequisite(new LevelPrerequisite(176));

		AddReward(new ExpReward(628002, 628002));
		AddReward(new ItemReward("expCard9", 3));
		AddReward(new ItemReward("Vis", 5280));

		AddDialogHook("THORN391_MQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("THORN391_MQ_05", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_1_MQ_02_1", "THORN39_1_MQ02", "Tell him that you would hand them over to him", "I need some time to prepare"))
			{
				case 1:
					await dialog.Msg("THORN39_1_MQ_02_2");
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
			await dialog.Msg("THORN39_1_MQ_02_11");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

