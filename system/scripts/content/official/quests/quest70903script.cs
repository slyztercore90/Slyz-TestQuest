//--- Melia Script -----------------------------------------------------------
// Here, Gobby Gobby
//--- Description -----------------------------------------------------------
// Quest to Talk with Investigation Team Head Ella.
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

[QuestScript(70903)]
public class Quest70903Script : QuestScript
{
	protected override void Load()
	{
		SetId(70903);
		SetName("Here, Gobby Gobby");
		SetDescription("Talk with Investigation Team Head Ella");

		AddPrerequisite(new CompletedPrerequisite("DCAPITAL103_SQ03"));
		AddPrerequisite(new LevelPrerequisite(303));

		AddReward(new ExpReward(12101740, 12101740));
		AddReward(new ItemReward("expCard13", 1));
		AddReward(new ItemReward("Vis", 13938));

		AddDialogHook("DCAPITAL103_SQ_01", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL103_SQ_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("DCAPITAL103_SQ_04_start", "DCAPITAL103_SQ04", "That's easy.", "Why not let your men do the job, if that is so important?"))
			{
				case 1:
					await dialog.Msg("DCAPITAL103_SQ_04_agree");
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
			await dialog.Msg("DCAPITAL103_SQ_04_succ");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

