//--- Melia Script -----------------------------------------------------------
// Everything Intact (1)
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

[QuestScript(60140)]
public class Quest60140Script : QuestScript
{
	protected override void Load()
	{
		SetId(60140);
		SetName("Everything Intact (1)");
		SetDescription("Talk with Priest Irma");

		AddPrerequisite(new CompletedPrerequisite("PRISON623_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("PRISON623_IRMA_02", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON621_URBONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON623_MQ_06_01", "PRISON623_MQ_06", "I will do that", "I can't just go"))
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

		return HookResult.Continue;
	}
}

