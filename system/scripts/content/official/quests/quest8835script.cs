//--- Melia Script -----------------------------------------------------------
// All the Same (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Adjutant General Hans.
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

[QuestScript(8835)]
public class Quest8835Script : QuestScript
{
	protected override void Load()
	{
		SetId(8835);
		SetName("All the Same (2)");
		SetDescription("Talk to Adjutant General Hans");

		AddPrerequisite(new CompletedPrerequisite("FLASH63_SQ_02"));
		AddPrerequisite(new LevelPrerequisite(193));

		AddReward(new ExpReward(1189715, 1189715));
		AddReward(new ItemReward("expCard10", 1));
		AddReward(new ItemReward("Vis", 5983));

		AddDialogHook("FLASH63_HANS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH63_HANS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH63_SQ_03_01", "FLASH63_SQ_03", "I'll go there", "About whether we could continue to do this", "Tell him to quit since it's dangerous"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("FLASH63_SQ_03_01_add");
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
			await dialog.Msg("FLASH63_SQ_03_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

