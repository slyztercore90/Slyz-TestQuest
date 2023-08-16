//--- Melia Script -----------------------------------------------------------
// Spiritual Poison (2)
//--- Description -----------------------------------------------------------
// Quest to Regret many souls and conversation.
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

[QuestScript(8312)]
public class Quest8312Script : QuestScript
{
	protected override void Load()
	{
		SetId(8312);
		SetName("Spiritual Poison (2)");
		SetDescription("Regret many souls and conversation");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 15 Blue Sakmoli(s)", new KillObjective(400564, 15));

		AddDialogHook("KATYN18_LOST_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_LOST_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_06_01", "KATYN18_MQ_06", "I'll get rid of the Black Sakamoli", "Cancel"))
			{
				case 1:
					await dialog.Msg("KATYN18_MQ_06_01_a");
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
			await dialog.Msg("KATYN18_MQ_06_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("KATYN18_MQ_07");
	}
}

