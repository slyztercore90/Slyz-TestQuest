//--- Melia Script -----------------------------------------------------------
// [Tutorial] Dialogue and Interaction
//--- Description -----------------------------------------------------------
// Quest to Talk to the refugee.
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

[QuestScript(63101)]
public class Quest63101Script : QuestScript
{
	protected override void Load()
	{
		SetId(63101);
		SetName("[Tutorial] Dialogue and Interaction");
		SetDescription("Talk to the refugee");

		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(440));

		AddDialogHook("EP14_MULIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("EP14_3LINE_TUTO_MQ_1_1_3");
			dialog.AddonMessage("NOTICE_Dm_Scroll", "Talk to the Illusion of the Girl ");
			// Func/SCR_SKIP_TUTO_SET_CLREAR_RUN_QUEST;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_1_2");
	}
}

