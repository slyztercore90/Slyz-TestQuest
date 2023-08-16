//--- Melia Script -----------------------------------------------------------
// Headstone on the West of Neryskus Grounds 
//--- Description -----------------------------------------------------------
// Quest to Find the Ancient Headstone and decipher it.
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

[QuestScript(91027)]
public class Quest91027Script : QuestScript
{
	protected override void Load()
	{
		SetId(91027);
		SetName("Headstone on the West of Neryskus Grounds ");
		SetDescription("Find the Ancient Headstone and decipher it");
		SetTrack("SSuccess", "ESuccess", "EP12_2_F_CASTLE_101_MQ03_3_TRACK_01", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ03"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ03_3_STONE", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ03_3_STONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ03_3_DLG_01", "EP12_2_F_CASTLE_101_MQ03_3", "I'll have a look around", "There won't be anything"))
			{
				case 1:
					await dialog.Msg("EP12_2_F_CASTLE_101_MQ03_3_DLG_02");
					dialog.UnHideNPC("EP12_2_F_CASTLE_101_MQ03_3_BRANCH");
					await dialog.Msg("BalloonText/EP12_2_F_CASTLE_101_MQ03_3_GOQUEST/3");
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
			if (character.Inventory.HasItem("EP12_2_F_CASTLE_101_MQ03_3_ITEM_01", 8))
			{
				character.Inventory.RemoveItem("EP12_2_F_CASTLE_101_MQ03_3_ITEM_01", 8);
				character.Quests.Complete(this.QuestId);
				dialog.HideNPC("EP12_2_F_CASTLE_101_MQ03_3_BRANCH");
			}
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

