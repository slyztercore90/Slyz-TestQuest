//--- Melia Script -----------------------------------------------------------
// The Owner of Necklace
//--- Description -----------------------------------------------------------
// Quest to Talk to Ejuidas the Mystery Man.
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

[QuestScript(90125)]
public class Quest90125Script : QuestScript
{
	protected override void Load()
	{
		SetId(90125);
		SetName("The Owner of Necklace");
		SetDescription("Talk to Ejuidas the Mystery Man");

		AddPrerequisite(new CompletedPrerequisite("MAPLE_25_2_SQ_60"));
		AddPrerequisite(new LevelPrerequisite(285));
		AddPrerequisite(new ItemPrerequisite("MAPLE_25_2_SQ_50_ITEM", -100));

		AddDialogHook("MAPLE_25_2_EIVYDAS", "BeforeStart", BeforeStart);
		AddDialogHook("MAPLE_25_2_EIVYDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MAPLE_25_2_SQ_70_ST", "MAPLE_25_2_SQ_70"))
			{
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

