//--- Melia Script -----------------------------------------------------------
// Cleaning the Church
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Algis.
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

[QuestScript(8534)]
public class Quest8534Script : QuestScript
{
	protected override void Load()
	{
		SetId(8534);
		SetName("Cleaning the Church");
		SetDescription("Talk to Follower Algis");

		AddPrerequisite(new CompletedPrerequisite("CHAPLE577_MQ_03"));
		AddPrerequisite(new LevelPrerequisite(48));

		AddObjective("kill0", "Kill 8 Egnome(s)", new KillObjective(57026, 8));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Vis", 720));

		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPLE577_ARUNE_02", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE577_MQ_07_01", "CHAPLE577_MQ_07", "Sure, I'll defeat it", "I don't have time for that"))
			{
				case 1:
					character.Quests.Start(this.QuestId);
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
			await dialog.Msg("CHAPLE577_MQ_07_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

