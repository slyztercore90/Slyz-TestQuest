//--- Melia Script -----------------------------------------------------------
// The Downward Spiral (8)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Zsaia.
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

[QuestScript(60297)]
public class Quest60297Script : QuestScript
{
	protected override void Load()
	{
		SetId(60297);
		SetName("The Downward Spiral (8)");
		SetDescription("Talk to Kupole Zsaia");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL106_SQ_7"));
		AddPrerequisite(new LevelPrerequisite(375));

		AddDialogHook("DCAPITAL106_ZUSAIA_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL106_GRISIA_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL106_SQ_8_1", "DCAPITAL106_SQ_8", "You should rest.", "Please wait."))
			{
				case 1:
					await dialog.Msg("FadeOutIN/1500");
					dialog.HideNPC("DCAPITAL106_ZUSAIA_NPC_2");
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
			await dialog.Msg("DCAPITAL106_SQ_8_3");
			await dialog.Msg("FadeOutIN/1500");
			dialog.HideNPC("DCAPITAL106_GRISIA_NPC_2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

