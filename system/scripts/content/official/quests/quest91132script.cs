//--- Melia Script -----------------------------------------------------------
// Sinking Seizure (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Loremaster Nijole at the Igti Coast.
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

[QuestScript(91132)]
public class Quest91132Script : QuestScript
{
	protected override void Load()
	{
		SetId(91132);
		SetName("Sinking Seizure (1)");
		SetDescription("Talk to Loremaster Nijole at the Igti Coast");
		SetTrack("SPossible", "ESuccess", "EP14_F_CORAL_RAID_5_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_F_CORAL_RAID_4"));
		AddPrerequisite(new LevelPrerequisite(470));

		AddDialogHook("EP14_F_CORAL_RAID_4_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_F_CORAL_RAID_1_NPC_1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_F_CORAL_RAID_5_SNPC_DLG1", "EP14_F_CORAL_RAID_5", "What's the meaning of this silence?", "Leave"))
			{
				case 1:
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
			await dialog.Msg("EP14_F_CORAL_RAID_5_CNPC_DLG1");
			dialog.HideNPC("EP14_F_CORAL_RAID_3_NPC_1");
			dialog.UnHideNPC("GODDESS_RAID_CORAL_PORTAL");
			dialog.HideNPC("EP14_F_CORAL_RAID_1_NPC_1");
			await dialog.Msg("FadeOutIN/2000");
			// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

