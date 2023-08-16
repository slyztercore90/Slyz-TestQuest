//--- Melia Script -----------------------------------------------------------
// Legend of the Winter Season (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Cryomancer Master.
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

[QuestScript(72171)]
public class Quest72171Script : QuestScript
{
	protected override void Load()
	{
		SetId(72171);
		SetName("Legend of the Winter Season (1)");
		SetDescription("Talk to the Cryomancer Master");

		AddPrerequisite(new CompletedPrerequisite("MASTER_ICEMAGE1"));
		AddPrerequisite(new LevelPrerequisite(45));

		AddDialogHook("MASTER_ICEMAGE", "BeforeStart", BeforeStart);
		AddDialogHook("SIAULIAIOUT_CHIEF_A", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("MASTER_CRYOMANCER2_1_DLG1", "MASTER_CRYOMANCER2_1", "I'll go find the book", "It sounds like a lie."))
			{
				case 1:
					await dialog.Msg("JOB_CRYOMANCER2_1_AG");
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
			await dialog.Msg("JOB_CRYOMANCER2_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("MASTER_CRYOMANCER2_2");
	}
}

