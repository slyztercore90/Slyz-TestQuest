//--- Melia Script -----------------------------------------------------------
// Headstone on the North of Neryskus Grounds Pathway
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

[QuestScript(91029)]
public class Quest91029Script : QuestScript
{
	protected override void Load()
	{
		SetId(91029);
		SetName("Headstone on the North of Neryskus Grounds Pathway");
		SetDescription("Find the Ancient Headstone and decipher it");
		SetTrack("SSuccess", "ESuccess", "EP12_2_F_CASTLE_101_MQ04_1_TRACK_01", "None");

		AddPrerequisite(new CompletedPrerequisite("EP12_2_F_CASTLE_101_MQ04"));
		AddPrerequisite(new LevelPrerequisite(450));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 32));
		AddReward(new ItemReward("Vis", 27900));

		AddDialogHook("EP12_2_F_CASTLE_101_MQ04_1_STONE", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_2_F_CASTLE_101_MQ04_1_STONE", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP12_2_F_CASTLE_101_MQ04_1_DLG_1", "EP12_2_F_CASTLE_101_MQ04_1", "Let's find a way", "You won't be able to find a way"))
			{
				case 1:
					await dialog.Msg("EP12_2_F_CASTLE_101_MQ04_1_DLG_2");
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

		return HookResult.Continue;
	}
}

