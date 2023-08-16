//--- Melia Script -----------------------------------------------------------
// Human's Hurdle
//--- Description -----------------------------------------------------------
// Quest to Talk to General Ramin.
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

[QuestScript(91125)]
public class Quest91125Script : QuestScript
{
	protected override void Load()
	{
		SetId(91125);
		SetName("Human's Hurdle");
		SetDescription("Talk to General Ramin");
		SetTrack("SPossible", "ESuccess", "EP14_1_RAID_PREVIEW_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP14_1_FCASTLE5_MQ_8"));
		AddPrerequisite(new LevelPrerequisite(468));

		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeStart", BeforeStart);
		AddDialogHook("EP14_1_FCASTLE5_MQ_8_NPC1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP14_1_FCASTLE5_MQ_9_SNPC_DLG1", "EP14_1_FCASTLE5_MQ_9", "Heard of it", "Never heard of it"))
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
			await dialog.Msg("FadeOutIN/2000");
			dialog.HideNPC("EP14_1_FCASTLE5_MQ_8_NPC2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

