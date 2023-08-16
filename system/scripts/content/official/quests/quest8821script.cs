//--- Melia Script -----------------------------------------------------------
// The Enemies of the Enemies are Monsters (2)
//--- Description -----------------------------------------------------------
// Quest to Talk with Grave Robber Rudolfas.
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

[QuestScript(8821)]
public class Quest8821Script : QuestScript
{
	protected override void Load()
	{
		SetId(8821);
		SetName("The Enemies of the Enemies are Monsters (2)");
		SetDescription("Talk with Grave Robber Rudolfas");

		AddPrerequisite(new CompletedPrerequisite("FLASH60_SQ_08"));
		AddPrerequisite(new LevelPrerequisite(187));

		AddReward(new ExpReward(475886, 475886));
		AddReward(new ItemReward("expCard10", 4));
		AddReward(new ItemReward("Vis", 5797));

		AddDialogHook("FLASH60_RUDOLFAS", "BeforeStart", BeforeStart);
		AddDialogHook("FLASH60_RUDOLFAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FLASH60_SQ_09_01", "FLASH60_SQ_09", "Tell him that you would finish the task well", "Reject"))
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
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("FLASH60_SQ_09_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

