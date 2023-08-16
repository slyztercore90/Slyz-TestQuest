//--- Melia Script -----------------------------------------------------------
// Strange Energy Emanating from the Statue
//--- Description -----------------------------------------------------------
// Quest to Investigate the Cursed Statue.
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

[QuestScript(50165)]
public class Quest50165Script : QuestScript
{
	protected override void Load()
	{
		SetId(50165);
		SetName("Strange Energy Emanating from the Statue");
		SetDescription("Investigate the Cursed Statue");
		SetTrack("SProgress", "ESuccess", "TABLELAND_72_SQ1_TRACK", 2000);

		AddPrerequisite(new LevelPrerequisite(246));

		AddObjective("kill0", "Kill 5 Red Hohen Orben(s) or Brown Lapasape(s)", new KillObjective(5, 57975, 57942));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 9102));

		AddDialogHook("TABLE72_ARTIFACT", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.Has(this.QuestId))
			character.Tracks.Start(this.TrackId);

		return HookResult.Continue;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("TABLELAND_72_SQ1_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

