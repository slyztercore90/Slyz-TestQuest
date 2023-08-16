//--- Melia Script -----------------------------------------------------------
// Reconstruction of the Blessing (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Albina.
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

[QuestScript(40450)]
public class Quest40450Script : QuestScript
{
	protected override void Load()
	{
		SetId(40450);
		SetName("Reconstruction of the Blessing (1)");
		SetDescription("Talk to Albina");
		SetTrack("SProgress", "ESuccess", "FARM47_1_SQ_090_TRACK", "m_boss_c");

		AddPrerequisite(new CompletedPrerequisite("FARM47_1_SQ_080"));
		AddPrerequisite(new LevelPrerequisite(93));

		AddObjective("kill0", "Kill 1 Kirmeleech", new KillObjective(57436, 1));
		AddObjective("kill1", "Kill 1 Completed Magic Circle", new KillObjective(153047, 1));

		AddReward(new ExpReward(221139, 221139));
		AddReward(new ItemReward("expCard6", 5));
		AddReward(new ItemReward("Vis", 1860));

		AddDialogHook("FARM47_ALBINA", "BeforeStart", BeforeStart);
		AddDialogHook("FARM47_ALBINA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("FARM47_1_SQ_090_ST", "FARM47_1_SQ_090", "I will eliminate the monsters", "About the reason that the monster sit down", "Reject since it's scary"))
			{
				case 1:
					await dialog.Msg("FARM47_1_SQ_090_AC");
					dialog.UnHideNPC("FARM47_FENCE_WALL");
					character.Quests.Start(this.QuestId);
					character.Tracks.Start(this.TrackId);
					break;
				case 2:
					await dialog.Msg("FARM47_1_SQ_090_ADD");
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
			await dialog.Msg("FARM47_1_SQ_090_COMP");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

