//--- Melia Script -----------------------------------------------------------
// Destroy the Suspicious Device
//--- Description -----------------------------------------------------------
// Quest to Speak with Loremaster Ugnius.
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

[QuestScript(90204)]
public class Quest90204Script : QuestScript
{
	protected override void Load()
	{
		SetId(90204);
		SetName("Destroy the Suspicious Device");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack("SProgress", "ESuccess", "CORAL_44_2_SQ_50_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_40"));
		AddPrerequisite(new LevelPrerequisite(331));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_OLDMAN2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_2_SQ_50_ST", "CORAL_44_2_SQ_50", "What do I have to do?", "I need some time to prepare."))
			{
				case 1:
					await dialog.Msg("CORAL_44_2_SQ_50_AG");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
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
			await dialog.Msg("CORAL_44_2_SQ_50_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

