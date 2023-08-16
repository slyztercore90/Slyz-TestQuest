//--- Melia Script -----------------------------------------------------------
// Fastidious Ointment (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Natasha.
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

[QuestScript(70140)]
public class Quest70140Script : QuestScript
{
	protected override void Load()
	{
		SetId(70140);
		SetName("Fastidious Ointment (2)");
		SetDescription("Talk to Hunter Natasha");

		AddPrerequisite(new CompletedPrerequisite("THORN39_1_MQ08"));
		AddPrerequisite(new LevelPrerequisite(179));

		AddDialogHook("THORN393_MQ_03", "BeforeStart", BeforeStart);
		AddDialogHook("THORN393_MQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN39_3_MQ_01_1", "THORN39_3_MQ01", "Tell him that you would persuade Goss", "I need some time to prepare"))
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
			await dialog.Msg("THORN39_3_MQ_01_2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

