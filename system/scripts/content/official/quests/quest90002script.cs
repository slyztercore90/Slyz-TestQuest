//--- Melia Script -----------------------------------------------------------
// The Corrupted Lake (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elder's Granddaughter.
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

[QuestScript(90002)]
public class Quest90002Script : QuestScript
{
	protected override void Load()
	{
		SetId(90002);
		SetName("The Corrupted Lake (3)");
		SetDescription("Talk to the Elder's Granddaughter");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_83_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddReward(new ItemReward("F_3CMLAKE_83_MQ_ITEM3", 1));

		AddDialogHook("3CMLAKE_83_LADY", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_83_WORKBENCH1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE_83_MQ_02_DLG_01", "F_3CMLAKE_83_MQ_02", "I will help", "I don't think I'm skilled enough to solve a problem like that"))
			{
				case 1:
					await dialog.Msg("3CMLAKE_83_MQ_02_DLG_02");
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

