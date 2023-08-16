//--- Melia Script -----------------------------------------------------------
// Dirty Tricks (1)
//--- Description -----------------------------------------------------------
// Quest to Inspect the Annex Laboratory beyond the Black Wall.
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

[QuestScript(80083)]
public class Quest80083Script : QuestScript
{
	protected override void Load()
	{
		SetId(80083);
		SetName("Dirty Tricks (1)");
		SetDescription("Inspect the Annex Laboratory beyond the Black Wall");

		AddPrerequisite(new CompletedPrerequisite("ABBEY_35_3_SQ_5"));
		AddPrerequisite(new LevelPrerequisite(229));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 63));
		AddReward(new ItemReward("Vis", 49464));

		AddDialogHook("ABBEY_35_3_DOMINIKAS_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeEnd(Dialog dialog)
	{
		var character = dialog.Player;
		if (character.Quests.IsCompletable(this.QuestId))
		{
			character.Quests.Complete(this.QuestId);
			await dialog.Msg("ABBEY_35_3_SQ_6_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("ABBEY_35_3_SQ_7");
	}
}

