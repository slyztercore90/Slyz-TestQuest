//--- Melia Script -----------------------------------------------------------
// Statue of Peace (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Elder's grandchild.
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

[QuestScript(80027)]
public class Quest80027Script : QuestScript
{
	protected override void Load()
	{
		SetId(80027);
		SetName("Statue of Peace (1)");
		SetDescription("Talk to the Elder's grandchild");

		AddPrerequisite(new CompletedPrerequisite("ORCHARD_323_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("ORCHARD323_GRANDSON", "BeforeStart", BeforeStart);
		AddDialogHook("ORCHARD323_VYDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("ORCHARD_323_SQ_04_start", "ORCHARD_323_SQ_04", "I will find out more about it", "Decline"))
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

