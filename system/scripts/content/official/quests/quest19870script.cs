//--- Melia Script -----------------------------------------------------------
// 
//--- Description -----------------------------------------------------------
// Quest to Talk to the Pilgrim.
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

[QuestScript(19870)]
public class Quest19870Script : QuestScript
{
	protected override void Load()
	{
		SetId(19870);
		SetDescription("Talk to the Pilgrim");

		AddPrerequisite(new LevelPrerequisite(9999));

		AddDialogHook("PILGRIM52_NPC01", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM52_NPC01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PILGRIM52_SQ_010_ST", "PILGRIM52_SQ_010", "I'll help", "Reason for coming in pilgrimage", "Decline"))
			{
				case 1:
					await dialog.Msg("PILGRIM52_SQ_010_AC");
					character.Quests.Start(this.QuestId);
					break;
				case 2:
					await dialog.Msg("PILGRIM52_SQ_010_ADD");
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
			await dialog.Msg("PILGRIM52_SQ_010_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

