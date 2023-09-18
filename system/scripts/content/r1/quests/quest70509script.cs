//--- Melia Script -----------------------------------------------------------
// The safety of the way back
//--- Description -----------------------------------------------------------
// Quest to Talk to Pilgrim Jacob.
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

[QuestScript(70509)]
public class Quest70509Script : QuestScript
{
	protected override void Load()
	{
		SetId(70509);
		SetName("The safety of the way back");
		SetDescription("Talk to Pilgrim Jacob");

		AddPrerequisite(new LevelPrerequisite(258));
		AddPrerequisite(new CompletedPrerequisite("PILGRIM41_1_SQ09"));

		AddObjective("kill0", "Kill 20 Brown Tini(s) or Green Tini Archer(s) or Blue Wendigo Shaman(s)", new KillObjective(20, 57903, 57907, 57870));

		AddReward(new ExpReward(985061, 985061));
		AddReward(new ItemReward("expCard12", 3));
		AddReward(new ItemReward("Vis", 10320));

		AddDialogHook("PILGRIM411_SQ_08", "BeforeStart", BeforeStart);
		AddDialogHook("PILGRIM411_SQ_08", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PILGRIM411_SQ_10_start", "PILGRIM41_1_SQ10", "Leave it to me", "Say that you think you have to go"))
		{
			case 1:
				await dialog.Msg("PILGRIM411_SQ_10_agree");
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

		await dialog.Msg("PILGRIM411_SQ_10_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

