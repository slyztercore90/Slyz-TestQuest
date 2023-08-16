//--- Melia Script -----------------------------------------------------------
// Fedimian Completionist [Archer Advancement] (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Archer Master.
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

[QuestScript(1121)]
public class Quest1121Script : QuestScript
{
	protected override void Load()
	{
		SetId(1121);
		SetName("Fedimian Completionist [Archer Advancement] (1)");
		SetDescription("Talk to the Archer Master");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("MASTER_ARCHER", "BeforeStart", BeforeStart);
		AddDialogHook("JOB_RODELERO3_1_NPC", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("JOB_ARCHER3_1_select1", "JOB_ARCHER3_1", "I'll go and find the Rodelero Master", "Decline"))
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
			await dialog.Msg("JOB_ARCHER3_1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("JOB_ARCHER3_2");
	}
}

