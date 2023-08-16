//--- Melia Script -----------------------------------------------------------
// Another Black Crystal
//--- Description -----------------------------------------------------------
// Quest to Investigate the Mirtinas Crevice again.
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

[QuestScript(91044)]
public class Quest91044Script : QuestScript
{
	protected override void Load()
	{
		SetId(91044);
		SetName("Another Black Crystal");
		SetDescription("Investigate the Mirtinas Crevice again");
		SetTrack("SSuccess", "ESuccess", "EP13_F_SIAULIAI_2_MQ_06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("EP13_F_SIAULIAI_2_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(452));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 15));
		AddReward(new ItemReward("Vis", 28024));

		AddDialogHook("EP13_F_SIAULIAI_2_MQ_03_CRACK", "BeforeStart", BeforeStart);
		AddDialogHook("EP13_F_SIAULIAI_2_MQ_06_BLACKCRYSTAL", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("EP13_F_SIAULIAI_2_MQ_06_DLG1", "EP13_F_SIAULIAI_2_MQ_06", "Investigate the Crevice", "Do other work for now"))
			{
				case 1:
					await dialog.Msg("BalloonText/EP13_F_SIAULIAI_2_MQ_06_DLG2/5");
					dialog.UnHideNPC("EP13_F_SIAULIAI_2_MQ_06_SMOKE");
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

