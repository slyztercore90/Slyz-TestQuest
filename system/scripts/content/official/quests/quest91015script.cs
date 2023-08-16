//--- Melia Script -----------------------------------------------------------
// Abnormal Severe Cold Wave of Stogas Plateau 
//--- Description -----------------------------------------------------------
// Quest to Find Crusader Envoy..
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

[QuestScript(91015)]
public class Quest91015Script : QuestScript
{
	protected override void Load()
	{
		SetId(91015);
		SetName("Abnormal Severe Cold Wave of Stogas Plateau ");
		SetDescription("Find Crusader Envoy.");
		SetTrack("SProgress", "ESuccess", "GLACIER_RAID_TUTO_RP_TRACK", "m_boss_a");

		AddPrerequisite(new CompletedPrerequisite("F_TABLELAND_28_2_RAID_01"));
		AddPrerequisite(new LevelPrerequisite(440));

		AddReward(new ItemReward("Ability_Point_Stone", 5));

		AddDialogHook("NPC_CRUSADER_02", "BeforeStart", BeforeStart);
		AddDialogHook("NPC_CRUSADER_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("GLACIER_TUTO_RP_DLG_01", "GLACIER_RAID_TUTO_RP_01", "Help with the investigation.", "Don't help with the investigation."))
			{
				case 1:
					await dialog.Msg("GLACIER_TUTO_RP_DLG_02");
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
			await dialog.Msg("GLACIER_TUTO_RP_DLG_04");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

