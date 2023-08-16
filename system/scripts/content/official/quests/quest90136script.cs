//--- Melia Script -----------------------------------------------------------
// Find the Trace (3)
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

[QuestScript(90136)]
public class Quest90136Script : QuestScript
{
	protected override void Load()
	{
		SetId(90136);
		SetName("Find the Trace (3)");
		SetDescription("Talk with Kupole Leda");
		SetTrack("SProgress", "ESuccess", "F_DCAPITAL_20_5_SQ_80_TRACK", "None");

		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_70"));
		AddPrerequisite(new LevelPrerequisite(292));

		AddObjective("kill0", "Kill 6 Scarecrow(s)", new KillObjective(58561, 6));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("F_DCAPITAL_20_5_SQ_80_ST", "F_DCAPITAL_20_5_SQ_80", "I will get down there immediately.", "I deserve some rest for now."))
			{
				case 1:
					await dialog.Msg("F_DCAPITAL_20_5_SQ_80_AG");
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
			await dialog.Msg("F_DCAPITAL_20_5_SQ_80_SU");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

