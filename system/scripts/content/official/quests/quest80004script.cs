//--- Melia Script -----------------------------------------------------------
// Suspicious Sanctum (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Grave Keeper Sigis.
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

[QuestScript(80004)]
public class Quest80004Script : QuestScript
{
	protected override void Load()
	{
		SetId(80004);
		SetName("Suspicious Sanctum (1)");
		SetDescription("Talk to Grave Keeper Sigis");

		AddPrerequisite(new CompletedPrerequisite("CATACOMB_33_1_SQ_04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("CATACOMB_33_1_SIGIS", "BeforeStart", BeforeStart);
		AddDialogHook("CATACOMB_33_1_SIGIS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CATACOMB_33_1_SQ_05_start", "CATACOMB_33_1_SQ_05", "I'll go there", "We need to find another way"))
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

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("CATACOMB_33_1_SQ_09");
	}
}

