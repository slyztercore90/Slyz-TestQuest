//--- Melia Script -----------------------------------------------------------
// The Fugitive's Dream (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Grisia.
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

[QuestScript(60304)]
public class Quest60304Script : QuestScript
{
	protected override void Load()
	{
		SetId(60304);
		SetName("The Fugitive's Dream (7)");
		SetDescription("Talk to Kupole Grisia");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL107_SQ_6"));
		AddPrerequisite(new LevelPrerequisite(378));

		AddDialogHook("DCAPITAL107_GRISIA_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL107_BLAD_NPC_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL107_SQ_7_1", "DCAPITAL107_SQ_7", "I will pass this along.", "That's too much"))
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
			await dialog.Msg("DCAPITAL107_SQ_7_3");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

