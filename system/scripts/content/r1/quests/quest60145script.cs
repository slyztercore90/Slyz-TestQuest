//--- Melia Script -----------------------------------------------------------
// Everything Intact (3)
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

[QuestScript(60145)]
public class Quest60145Script : QuestScript
{
	protected override void Load()
	{
		SetId(60145);
		SetName("Everything Intact (3)");
		SetDescription("Talk with Inesa Hamondale");

		AddPrerequisite(new LevelPrerequisite(9999));
		AddPrerequisite(new CompletedPrerequisite("PRISON623_MQ_07"));

		AddDialogHook("C_ORSHA_HAMONDAIL", "BeforeStart", BeforeStart);
		AddDialogHook("C_ORSHA_URBONAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("ORSHA_MQ3_01_01", "ORSHA_MQ3_01", "I will go there right away", "There are still some things to do"))
		{
			case 1:
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;


		return HookResult.Break;
	}
}

