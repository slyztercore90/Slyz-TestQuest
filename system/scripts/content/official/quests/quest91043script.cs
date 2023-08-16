//--- Melia Script -----------------------------------------------------------
// Destroy Black Crystal
//--- Description -----------------------------------------------------------
// Quest to Destroy Beholder's Black Crystal.
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

[QuestScript(91043)]
public class Quest91043Script : QuestScript
{
	protected override void Load()
	{
		SetId(91043);
		SetName("Destroy Black Crystal");
		SetDescription("Destroy Beholder's Black Crystal");
		SetTrack("SPossible", "ESuccess", "EP13_F_SIAULIAI_2_MQ_05_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(452));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_04_BLACKCRYSTAL", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_03_CRACK", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_05_DLG1", "EP13_F_SIAULIAI_2_MQ_05", "Use Goddess Lada's Blessing", "Stop since it seems dangerous"))
			{
				case 1:
					dialog.HideNPC("EP13_F_SIAULIAI_2_MQ_04_BLACKCRYSTAL");
					dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_05_AFTER");
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
			await dialog.Msg("BalloonText/EP13_F_SIAULIAI_2_MQ_05_DLG2/8");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

