//--- Melia Script -----------------------------------------------------------
// The Missing Bishop (1)
//--- Description -----------------------------------------------------------
// Quest to Talk with Inesa Hamondale.
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

[QuestScript(60085)]
public class Quest60085Script : QuestScript
{
	protected override void Load()
	{
		SetId(60085);
		SetName("The Missing Bishop (1)");
		SetDescription("Talk with Inesa Hamondale");

		AddPrerequisite(new CompletedPrerequisite("SIAU16_MQ_07"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORSHA_MQ1_01_01", "ORSHA_MQ1_01", "I'll help you if you take me to the bishop of Orsha", "I'm afraid that'll be impossible"))
			{
				case 1:
					await dialog.Msg("ORSHA_MQ1_01_01_1");
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

