//--- Melia Script -----------------------------------------------------------
// [Tutorial] Equip Growth Equipment
//--- Description -----------------------------------------------------------
// Quest to Talk to the Illusion of the Girl .
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

[QuestScript(63102)]
public class Quest63102Script : QuestScript
{
	protected override void Load()
	{
		SetId(63102);
		SetName("[Tutorial] Equip Growth Equipment");
		SetDescription("Talk to the Illusion of the Girl ");

		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_1_1"));
		AddPrerequisite(new LevelPrerequisite(440));

		AddDialogHook("EP14_MULIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_MULIA_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_3LINE_TUTO_MQ_1_2_1", "EP14_3LINE_TUTO_MQ_1_2", "Alright", "Reject"))
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
			await dialog.Msg("EP14_3LINE_TUTO_MQ_1_2_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_2");
	}
}

