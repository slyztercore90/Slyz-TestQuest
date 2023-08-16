//--- Melia Script -----------------------------------------------------------
// Conclusion with Different Interests
//--- Description -----------------------------------------------------------
// Quest to Talk to Solcomm.
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

[QuestScript(72121)]
public class Quest72121Script : QuestScript
{
	protected override void Load()
	{
		SetId(72121);
		SetName("Conclusion with Different Interests");
		SetDescription("Talk to Solcomm");
		SetTrack("SProgress", "ESuccess", "F_3CMLAKE262_SQ07_TRACK", "m_boss_scenario");

		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE262_SQ06"));
		AddPrerequisite(new LevelPrerequisite(336));

		AddObjective("kill0", "Kill 1 Demon Lord Solcomm", new KillObjective(105001, 1));

		AddReward(new ExpReward(36303568, 36303568));
		AddReward(new ItemReward("expCard14", 2));
		AddReward(new ItemReward("Vis", 15792));

		AddDialogHook("3CMLAKE_SOLCOMM", "BeforeStart", BeforeStart);
		AddDialogHook("3CMLAKE_BLACKMAN04", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("3CMLAKE262_SQ07_DLG01", "F_3CMLAKE262_SQ07", "I'll listen to it.", "I won't listen to it."))
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
			await dialog.Msg("3CMLAKE262_SQ07_DLG02");
			// Func/SCR_F_3CMLAKE262_SQ07_END;
			dialog.HideNPC("3CMLAKE_BLACKMAN04");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

