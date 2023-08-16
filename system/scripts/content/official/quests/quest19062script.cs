//--- Melia Script -----------------------------------------------------------
// The Wizard and the Mage Tower (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Simon Shaw.
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

[QuestScript(19062)]
public class Quest19062Script : QuestScript
{
	protected override void Load()
	{
		SetId(19062);
		SetName("The Wizard and the Mage Tower (2)");
		SetDescription("Talk to Simon Shaw");

		AddPrerequisite(new CompletedPrerequisite("FIRETOWER_45_HQ_01"));
		AddPrerequisite(new LevelPrerequisite(119));

		AddDialogHook("FTOWER45_SQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("FTOWER45_SQ_03", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FIRETOWER_45_HQ_02_ST", "FIRETOWER_45_HQ_02", "I will do it", "Decline"))
			{
				case 1:
					await dialog.Msg("FIRETOWER_45_HQ_02_AC");
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
			await dialog.Msg("FIRETOWER_45_HQ_02_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

