//--- Melia Script -----------------------------------------------------------
// Mysterious Wizard
//--- Description -----------------------------------------------------------
// Quest to Return to Rose and deliver the diary.
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

[QuestScript(50110)]
public class Quest50110Script : QuestScript
{
	protected override void Load()
	{
		SetId(50110);
		SetName("Mysterious Wizard");
		SetDescription("Return to Rose and deliver the diary");
		SetTrack("SProgress", "ESuccess", "BRACKEN_63_3_MQ030_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("BRACKEN_63_3_MQ020"));
		AddPrerequisite(new LevelPrerequisite(9999));

		AddObjective("kill0", "Kill 15 Vubbe Warrior(s) or Lapasape Mage(s)", new KillObjective(15, 103024, 57640));

		AddReward(new ExpReward(168840, 168840));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 504));

		AddDialogHook("BRACKEN633_ROZE_TRIGGER", "BeforeStart", BeforeStart);
		AddDialogHook("BRACKEN633_ROZE01", "BeforeEnd", BeforeEnd);
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

		return HookResult.Continue;
	}
}

