//--- Melia Script -----------------------------------------------------------
// Can't Sell Without It
//--- Description -----------------------------------------------------------
// Quest to Talk to Treasure Hunter Eden.
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

[QuestScript(20206)]
public class Quest20206Script : QuestScript
{
	protected override void Load()
	{
		SetId(20206);
		SetName("Can't Sell Without It");
		SetDescription("Talk to Treasure Hunter Eden");

		AddPrerequisite(new LevelPrerequisite(96));

		AddReward(new ExpReward(73713, 73713));
		AddReward(new ItemReward("expCard6", 3));
		AddReward(new ItemReward("Vis", 1920));

		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeStart", BeforeStart);
		AddDialogHook("REMAIN37_SQ6_UNCLE1", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("REMAIN37_SQ03_select01", "REMAIN37_SQ03", "I'll do it", "Think more about it"))
		{
			case 1:
				await dialog.Msg("REMAIN37_SQ03_AG");
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

		await dialog.Msg("REMAIN37_SQ03_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

