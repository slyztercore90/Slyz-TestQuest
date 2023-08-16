//--- Melia Script -----------------------------------------------------------
// Village Curse (7)
//--- Description -----------------------------------------------------------
// Quest to Talk to Village Priest Chaleims.
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

[QuestScript(50172)]
public class Quest50172Script : QuestScript
{
	protected override void Load()
	{
		SetId(50172);
		SetName("Village Curse (7)");
		SetDescription("Talk to Village Priest Chaleims");
		SetTrack("SProgress", "ESuccess", "TABLELAND_72_SQ8_TRACK", 2000);

		AddPrerequisite(new CompletedPrerequisite("TABLELAND_72_SQ7"));
		AddPrerequisite(new LevelPrerequisite(246));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 100122));

		AddDialogHook("TABLE72_PEAPLE1_2", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE72_PEAPLE1_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("TABLELAND_72_SQ8_startnpc1", "TABLELAND_72_SQ8", "I'll protect you.", "Everything will be alright"))
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
			await dialog.Msg("TABLELAND_72_SQ8_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

