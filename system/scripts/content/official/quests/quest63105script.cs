//--- Melia Script -----------------------------------------------------------
// [Tutorial] First Advancement
//--- Description -----------------------------------------------------------
// Quest to Talk to Illusion of the Girl .
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

[QuestScript(63105)]
public class Quest63105Script : QuestScript
{
	protected override void Load()
	{
		SetId(63105);
		SetName("[Tutorial] First Advancement");
		SetDescription("Talk to Illusion of the Girl ");

		AddPrerequisite(new CompletedPrerequisite("EP14_3LINE_TUTO_MQ_3"));
		AddPrerequisite(new LevelPrerequisite(440));

		AddDialogHook("EP14_MULIA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_MULIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_3LINE_TUTO_MQ_3_1_1", "EP14_3LINE_TUTO_MQ_3_1", "I'll try the Advancement", "I don't think that's needed,"))
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
			await dialog.Msg("EP14_3LINE_TUTO_MQ_3_1_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("EP14_3LINE_TUTO_MQ_4");
	}
}

