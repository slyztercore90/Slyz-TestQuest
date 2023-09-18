//--- Melia Script -----------------------------------------------------------
// Setbacks (4)
//--- Description -----------------------------------------------------------
// Quest to Talk to Jamelhan.
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

[QuestScript(50160)]
public class Quest50160Script : QuestScript
{
	protected override void Load()
	{
		SetId(50160);
		SetName("Setbacks (4)");
		SetDescription("Talk to Jamelhan");

		AddPrerequisite(new LevelPrerequisite(242));
		AddPrerequisite(new CompletedPrerequisite("TABLELAND_71_SQ3"));

		AddReward(new ExpReward(5910366, 5910366));
		AddReward(new ItemReward("expCard12", 2));
		AddReward(new ItemReward("Vis", 8954));

		AddDialogHook("TABLE71_PEAPLE1", "BeforeStart", BeforeStart);
		AddDialogHook("TABLE71_PEAPLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("TABLELAND_71_SQ4_startnpc1", "TABLELAND_71_SQ4", "Leave it to me", "I can only help so much"))
		{
			case 1:
				await dialog.Msg("TABLELAND_71_SQ4_startnpc2");
				character.Quests.Start(this.QuestId);
				break;
		}

		return HookResult.Break;
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsCompletable(this.QuestId))
			return HookResult.Skip;

		await dialog.Msg("TABLELAND_71_SQ4_succ1");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

