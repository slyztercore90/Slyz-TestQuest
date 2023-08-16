//--- Melia Script -----------------------------------------------------------
// A Deeper Place (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Irma.
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

[QuestScript(60136)]
public class Quest60136Script : QuestScript
{
	protected override void Load()
	{
		SetId(60136);
		SetName("A Deeper Place (1)");
		SetDescription("Talk with Priest Irma");

		AddPrerequisite(new CompletedPrerequisite("PRISON622_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ExpReward(13430, 13430));
		AddReward(new ItemReward("expCard2", 1));
		AddReward(new ItemReward("Vis", 350));

		AddDialogHook("PRISON623_IRMA_01", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON623_IRMA_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON623_MQ_01_01", "PRISON623_MQ_01", "I will try", "I'm afraid that'll be impossible"))
			{
				case 1:
					await dialog.Msg("PRISON623_MQ_01_01_AG");
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

