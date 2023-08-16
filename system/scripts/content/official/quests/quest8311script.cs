//--- Melia Script -----------------------------------------------------------
// Spiritual Poison (1)
//--- Description -----------------------------------------------------------
// Quest to Lost souls and conversation.
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

[QuestScript(8311)]
public class Quest8311Script : QuestScript
{
	protected override void Load()
	{
		SetId(8311);
		SetName("Spiritual Poison (1)");
		SetDescription("Lost souls and conversation");

		AddPrerequisite(new CompletedPrerequisite("KATYN18_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 9 Red Puragi(s)", new KillObjective(400304, 9));

		AddDialogHook("KATYN18_LOST_01", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN18_LOST_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN18_MQ_05_01", "KATYN18_MQ_05", "I'll get rid of the Puragi", "Cancel"))
			{
				case 1:
					await dialog.Msg("KATYN18_MQ_05_01_a");
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
			await dialog.Msg("KATYN18_MQ_05_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

