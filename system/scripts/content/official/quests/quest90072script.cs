//--- Melia Script -----------------------------------------------------------
// Raising an Altar (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Daroul.
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

[QuestScript(90072)]
public class Quest90072Script : QuestScript
{
	protected override void Load()
	{
		SetId(90072);
		SetName("Raising an Altar (2)");
		SetDescription("Talk to Loremaster Daroul");

		AddPrerequisite(new CompletedPrerequisite("CORAL_32_2_SQ_3"));
		AddPrerequisite(new LevelPrerequisite(235));

		AddDialogHook("CORAL_32_2_DARUL1", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_32_2_BERTA2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_32_2_SQ_4_ST", "CORAL_32_2_SQ_4", "I'll go and help you a bit more.", "I will think about it"))
			{
				case 1:
					await dialog.Msg("CORAL_32_2_SQ_4_AG");
					dialog.HideNPC("CORAL_32_2_DARUL1");
					await dialog.Msg("FadeOutIN/2000");
					dialog.UnHideNPC("CORAL_32_2_BERTA2");
					dialog.UnHideNPC("CORAL_32_2_DARUL2");
					dialog.UnHideNPC("JURATEALTAR");
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
			await dialog.Msg("CORAL_32_2_SQ_4_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

