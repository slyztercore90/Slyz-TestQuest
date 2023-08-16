//--- Melia Script -----------------------------------------------------------
// Clear the Corruption (6)
//--- Description -----------------------------------------------------------
// Quest to Talk to Hunter Modis.
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

[QuestScript(90015)]
public class Quest90015Script : QuestScript
{
	protected override void Load()
	{
		SetId(90015);
		SetName("Clear the Corruption (6)");
		SetDescription("Talk to Hunter Modis");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE_84_MQ_06_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_84_MQ_05"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 1 Tyronas Hydra", new KillObjective(58209, 1));

		AddReward(new ExpReward(614275, 614275));
		AddReward(new ItemReward("expCard5", 5));
		AddReward(new ItemReward("Vis", 11628));
		AddReward(new ItemReward("TreasureboxKey2", 1));

		AddDialogHook("3CMLAKE_84_HUNTER", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_84_OLDMAN", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE_84_MQ_06_DLG_01", "F_3CMLAKE_84_MQ_06", "I'll go and catch the Hydra", "I need some time to prepare"))
			{
				case 1:
					await dialog.Msg("3CMLAKE_84_MQ_06_DLG_AG");
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

