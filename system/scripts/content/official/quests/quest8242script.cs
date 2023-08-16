//--- Melia Script -----------------------------------------------------------
// The Missing Troop (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Officer Danus.
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

[QuestScript(8242)]
public class Quest8242Script : QuestScript
{
	protected override void Load()
	{
		SetId(8242);
		SetName("The Missing Troop (1)");
		SetDescription("Talk to Officer Danus");

		AddPrerequisite(new LevelPrerequisite(114));

		AddDialogHook("KATYN14_LAIMUNAS", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN14_VACENIN_CHASE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN14_MQ_01_01", "KATYN14_MQ_01", "I will find the scout", "I'm sorry but I can't"))
			{
				case 1:
					await dialog.Msg("KATYN14_MQ_01_AG");
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
			await dialog.Msg("KATYN14_MQ_01_03");
			dialog.UnHideNPC("KATYN14_VACENIN_CHASE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

