//--- Melia Script -----------------------------------------------------------
// The Suspicious Dagger (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pyromancer Master.
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

[QuestScript(50011)]
public class Quest50011Script : QuestScript
{
	protected override void Load()
	{
		SetId(50011);
		SetName("The Suspicious Dagger (1)");
		SetDescription("Talk to the Pyromancer Master");

		AddPrerequisite(new CompletedPrerequisite("SIAULIAI_50_1_SQ_030"));
		AddPrerequisite(new LevelPrerequisite(69));

		AddDialogHook("MASTER_FIREMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("MASTER_BOCORS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("SIAULIAI_50_1_SQ_040_select01", "SIAULIAI_50_1_SQ_040", "I'll go there", "Decline"))
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
			await dialog.Msg("SIAULIAI_50_1_SQ_040_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("SIAULIAI_50_1_SQ_050");
	}
}

