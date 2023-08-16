//--- Melia Script -----------------------------------------------------------
// Good Idea (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Pajauta.
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

[QuestScript(92040)]
public class Quest92040Script : QuestScript
{
	protected override void Load()
	{
		SetId(92040);
		SetName("Good Idea (1)");
		SetDescription("Talk to Pajauta");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_SQ_01"));
		AddPrerequisite(new LevelPrerequisite(452));

		AddDialogHook("EP13_SUB_PAYAUTA_NPC_SIAU_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_2_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_2_SQ_02_1", "EP13_F_SIAULIAI_2_SQ_02", "What a genius idea", "I'm confused"))
			{
				case 1:
					await dialog.Msg("EP13_F_SIAULIAI_2_SQ_02_1_1");
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
			await dialog.Msg("EP13_F_SIAULIAI_2_SQ_02_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

