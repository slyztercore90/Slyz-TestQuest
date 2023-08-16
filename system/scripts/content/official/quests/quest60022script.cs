//--- Melia Script -----------------------------------------------------------
// Hauberk in the Maze (5)
//--- Description -----------------------------------------------------------
// Quest to Talk to Kupole Sigita.
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

[QuestScript(60022)]
public class Quest60022Script : QuestScript
{
	protected override void Load()
	{
		SetId(60022);
		SetName("Hauberk in the Maze (5)");
		SetDescription("Talk to Kupole Sigita");
		SetTrack("SProgress", "ESuccess", "VPRISON513_MQ_05_TRACK", "m_booss_a");

		AddPrerequisite(new CompletedPrerequisite("VPRISON513_MQ_04"));
		AddPrerequisite(new LevelPrerequisite(160));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 9));
		AddReward(new ItemReward("Vis", 38400));

		AddDialogHook("VPRISON513_MQ_SIGITA", "BeforeStart", BeforeStart);
		AddDialogHook("VPRISON513_MQ_SIGITA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("VPRISON513_MQ_05_01", "VPRISON513_MQ_05", "I am ready", "I will prepare a lot"))
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
			await dialog.Msg("VPRISON513_MQ_05_03");
			dialog.UnHideNPC("VPRISON515_MQ_06_NPC");
			dialog.HideNPC("VPRISON514_MQ_VAKARINE");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

