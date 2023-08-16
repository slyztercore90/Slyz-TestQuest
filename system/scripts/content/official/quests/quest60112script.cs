//--- Melia Script -----------------------------------------------------------
// The Dangerous Trace (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Priest Pranas.
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

[QuestScript(60112)]
public class Quest60112Script : QuestScript
{
	protected override void Load()
	{
		SetId(60112);
		SetName("The Dangerous Trace (1)");
		SetDescription("Talk with Priest Pranas");

		AddPrerequisite(new CompletedPrerequisite("SIAU11RE_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("C_ORSHA_PRANAS", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORSHA_MQ2_01_01", "ORSHA_MQ2_01", "I want to hear it", "I need to prepare myself"))
			{
				case 1:
					await dialog.Msg("ORSHA_MQ2_01_01_01");
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

