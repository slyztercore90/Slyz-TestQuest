//--- Melia Script -----------------------------------------------------------
// Trace Race (6)
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90145)]
public class Quest90145Script : QuestScript
{
	protected override void Load()
	{
		SetId(90145);
		SetName("Trace Race (6)");
		SetDescription("Talk with Kupole Leda");
		SetTrack("SProgress", "ESuccess", "F_DCAPITAL_20_6_SQ_60_TRACK", "m_boss_b");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_6_SQ_55"));
		AddPrerequisite(new LevelPrerequisite(295));

		AddReward(new ExpReward(4840696, 4840696));
		AddReward(new ItemReward("expCard13", 4));
		AddReward(new ItemReward("Vis", 12390));

		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_DCAPITAL_20_6_SQ_60_ST", "F_DCAPITAL_20_6_SQ_60", "Next stop, Jonael's place,", "I need some moment to rest."))
			{
				case 1:
					await dialog.Msg("F_DCAPITAL_20_6_SQ_60_AG");
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
			await dialog.Msg("F_DCAPITAL_20_6_SQ_70_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

