//--- Melia Script -----------------------------------------------------------
// Bully
//--- Description -----------------------------------------------------------
// Quest to Talk to Follower Vaidas.
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

[QuestScript(8526)]
public class Quest8526Script : QuestScript
{
	protected override void Load()
	{
		SetId(8526);
		SetName("Bully");
		SetDescription("Talk to Follower Vaidas");

		AddPrerequisite(new CompletedPrerequisite("CHAPLE575_MQ_06"));
		AddPrerequisite(new LevelPrerequisite(40));

		AddObjective("kill0", "Kill 2 Glizardon(s)", new KillObjective(57021, 2));

		AddReward(new ExpReward(50652, 50652));
		AddReward(new ItemReward("expCard3", 4));
		AddReward(new ItemReward("Drug_SP1_Q", 30));
		AddReward(new ItemReward("Vis", 600));

		AddDialogHook("CHAPEL_VIDAS", "BeforeStart", BeforeStart);
		AddDialogHook("CHAPEL_VIDAS", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("CHAPLE575_MQ_08_01", "CHAPLE575_MQ_08", "I will try", "That's too much to handle"))
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
			await dialog.Msg("CHAPLE575_MQ_08_03");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

