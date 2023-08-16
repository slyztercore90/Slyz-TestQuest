//--- Melia Script -----------------------------------------------------------
// Extra Extra Careful (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Oort.
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

[QuestScript(80291)]
public class Quest80291Script : QuestScript
{
	protected override void Load()
	{
		SetId(80291);
		SetName("Extra Extra Careful (1)");
		SetDescription("Talk to Hunter Oort");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("F_3CMLAKE_87_MQ_07_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_87_MQ_07_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_3CMLAKE_87_MQ_07_ST", "F_3CMLAKE_87_MQ_07", "I'll try to find it.", "I don't think there's a need for that."))
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

