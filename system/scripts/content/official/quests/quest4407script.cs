//--- Melia Script -----------------------------------------------------------
// One More Time
//--- Description -----------------------------------------------------------
// Quest to Talk to the Worrying Owl Sculpture..
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

[QuestScript(4407)]
public class Quest4407Script : QuestScript
{
	protected override void Load()
	{
		SetId(4407);
		SetName("One More Time");
		SetDescription("Talk to the Worrying Owl Sculpture.");

		AddPrerequisite(new CompletedPrerequisite("THORN23_Q_16"));
		AddPrerequisite(new LevelPrerequisite(123));

		AddReward(new ExpReward(180936, 180936));
		AddReward(new ItemReward("expCard7", 3));
		AddReward(new ItemReward("Vis", 3075));

		AddDialogHook("THORN23_OWL3", "BeforeStart", BeforeStart);
		AddDialogHook("THORN23_OWL3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("THORN23_Q_17_select1", "THORN23_Q_17", "I'll do it", "Help him with his mental readiness"))
			{
				case 1:
					await dialog.Msg("NPCState;d_thorn_23/515");
					await dialog.Msg("NPCState;d_thorn_23/516");
					await dialog.Msg("NPCState;d_thorn_23/517");
					await dialog.Msg("THORN23_Q_17_startnpc01");
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
			await dialog.Msg("NPCState;d_thorn_23/518");
			await dialog.Msg("THORN23_Q_17_succ1");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}

	public void OnComplete(Character character, Quest quest)
	{
		character.Quests.Start("THORN23_BOSSKILL_1");
	}
}

