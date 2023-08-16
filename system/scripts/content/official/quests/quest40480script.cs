//--- Melia Script -----------------------------------------------------------
// {memo  This name/function means that this is a list of people to sign on}The compact under joint signatures
//--- Description -----------------------------------------------------------
// Quest to Discuss with Horacius.
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

[QuestScript(40480)]
public class Quest40480Script : QuestScript
{
	protected override void Load()
	{
		SetId(40480);
		SetName("{memo  This name/function means that this is a list of people to sign on}The compact under joint signatures");
		SetDescription("Discuss with Horacius");

		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_040"), new CompletedPrerequisite("FARM47_1_SQ_080"), new CompletedPrerequisite("FARM47_1_SQ_070"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("FARM47_LEADER", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_LEADER", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_1_SQ_120_ST", "FARM47_1_SQ_120", "Ask him what is the only thing", "About the plan", "I should go on my way now"))
			{
				case 1:
					await dialog.Msg("FARM47_1_SQ_120_AC");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("FARM47_1_SQ_120_ADD");
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
			await dialog.Msg("FARM47_1_SQ_120_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

