//--- Melia Script -----------------------------------------------------------
// Identifying the Magic Circle
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

[QuestScript(90201)]
public class Quest90201Script : QuestScript
{
	protected override void Load()
	{
		SetId(90201);
		SetName("Identifying the Magic Circle");
		SetDescription("Speak with Loremaster Ugnius");
		SetTrack("SProgress", "ESuccess", "CORAL_44_2_SQ_20_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("CORAL_44_2_SQ_10"));
		AddPrerequisite(new LevelPrerequisite(331));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));

		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeStart", BeforeStart);
		AddDialogHook("CORAL_44_2_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CORAL_44_2_SQ_20_ST", "CORAL_44_2_SQ_20", "Talk about what you witnessed at the occupied lowlands.", "There was nothing new."))
			{
				case 1:
					await dialog.Msg("CORAL_44_2_SQ_20_AG");
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
			if (character.Inventory.HasItem("CORAL_44_2_SQ_20_ITEM", 1))
			{
				character.Inventory.RemoveItem("CORAL_44_2_SQ_20_ITEM", 1);
				character.Quests.Complete(this.QuestId);
				await dialog.Msg("CORAL_44_2_SQ_20_SU");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

