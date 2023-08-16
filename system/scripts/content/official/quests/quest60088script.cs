//--- Melia Script -----------------------------------------------------------
// The Missing Bishop (4)
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

[QuestScript(60088)]
public class Quest60088Script : QuestScript
{
	protected override void Load()
	{
		SetId(60088);
		SetName("The Missing Bishop (4)");
		SetDescription("Talk with Inesa Hamondale");

		AddPrerequisite(new CompletedPrerequisite("ORSHA_MQ1_03"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAI15RE_CHERASIA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORSHA_MQ1_04_01", "ORSHA_MQ1_04", "I will go there right away", "I'm not quite ready yet"))
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

