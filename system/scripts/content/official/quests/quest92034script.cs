//--- Melia Script -----------------------------------------------------------
// Kingdom Reconstruction's Request
//--- Description -----------------------------------------------------------
// Quest to Talk to Orsha Damage Recovery Team.
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

[QuestScript(92034)]
public class Quest92034Script : QuestScript
{
	protected override void Load()
	{
		SetId(92034);
		SetName("Kingdom Reconstruction's Request");
		SetDescription("Talk to Orsha Damage Recovery Team");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_1_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_1_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_SUB_RECONSTRUCTION_NPC_SIAU_1_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_1_SQ_01_1", "EP13_F_SIAULIAI_1_SQ_01", "I am the Revelator and I'll gladly help you", "Say you have other matters to attend to"))
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
			await dialog.Msg("EP13_F_SIAULIAI_1_SQ_01_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

