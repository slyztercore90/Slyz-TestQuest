//--- Melia Script -----------------------------------------------------------
// Dangerous Throneweaver (3)
//--- Description -----------------------------------------------------------
// Quest to Talk to the Sad Owl Sculpture.
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

[QuestScript(8358)]
public class Quest8358Script : QuestScript
{
	protected override void Load()
	{
		SetId(8358);
		SetName("Dangerous Throneweaver (3)");
		SetDescription("Talk to the Sad Owl Sculpture");
		SetTrack("SProgress", "ESuccess", "KATYN7_2_ADD_BOSS_01_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("KATYN72_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(109));

		AddObjective("kill0", "Kill 1 Throneweaver", new KillObjective(41221, 1));

		AddReward(new ExpReward(361872, 361872));
		AddReward(new ItemReward("expCard7", 4));
		AddReward(new ItemReward("TreasureboxKey3", 1));
		AddReward(new ItemReward("Vis", 2616));

		AddDialogHook("KATYN72_SECTOR_02", "BeforeStart", BeforeStart);
		AddDialogHook("KATYN72_SECTOR_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("KATYN72_MQ_07_01", "KATYN7_2_ADD_BOSS_01", "I'll get rid of the Throneweaver", "Give me some time to prepare"))
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
			await dialog.Msg("KATYN72_MQ_07_03");
			dialog.HideNPC("KATYN7_2_FALL");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

