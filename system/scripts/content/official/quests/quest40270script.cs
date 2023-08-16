//--- Melia Script -----------------------------------------------------------
// Where is the Food
//--- Description -----------------------------------------------------------
// Quest to Talk to Baron Secretary Benius.
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

[QuestScript(40270)]
public class Quest40270Script : QuestScript
{
	protected override void Load()
	{
		SetId(40270);
		SetName("Where is the Food");
		SetDescription("Talk to Baron Secretary Benius");
		SetTrack("SProgress", "ESuccess", "FARM47_3_SQ_100_TRACK", "m_boss_b");

		AddPrerequisite(new LevelPrerequisite(86));

		AddObjective("kill0", "Kill 1 Manticen", new KillObjective(57434, 1));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1720));

		AddDialogHook("FARM47_BENIUS", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_BENIUS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_3_SQ_100_ST", "FARM47_3_SQ_100", "I will find it", "About Manticen", "I don't have time for that"))
			{
				case 1:
					await dialog.Msg("FARM47_3_SQ_100_AC");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("FARM47_3_SQ_100_ADD");
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
			await dialog.Msg("FARM47_3_SQ_100_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

