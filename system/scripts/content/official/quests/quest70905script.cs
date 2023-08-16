//--- Melia Script -----------------------------------------------------------
// Parchment Enthusiast
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigation Team Head Ella.
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

[QuestScript(70905)]
public class Quest70905Script : QuestScript
{
	protected override void Load()
	{
		SetId(70905);
		SetName("Parchment Enthusiast");
		SetDescription("Talk with Investigation Team Head Ella");
		SetTrack("SProgress", "ESuccess", "DCAPITAL103_SQ06_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ05"));
		AddPrerequisite(new LevelPrerequisite(303));

		AddObjective("kill0", "Kill 1 Fallen City Basilisk", new KillObjective(58574, 1));

		AddReward(new ExpReward(24203480, 24203480));
		AddReward(new ItemReward("expCard13", 2));
		AddReward(new ItemReward("Vis", 13938));
		AddReward(new ItemReward("DCAPITAL103_BOOK1", 1));

		AddDialogHook("DCAPITAL103_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL103_SQ_06_start", "DCAPITAL103_SQ06", "I will search the place and find the cause.", "I value my continued existence, thank you very much."))
			{
				case 1:
					await dialog.Msg("DCAPITAL103_SQ_06_agree");
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
			await dialog.Msg("DCAPITAL103_SQ_06_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

