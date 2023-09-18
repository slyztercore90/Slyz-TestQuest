//--- Melia Script -----------------------------------------------------------
// To find another trace
//--- Description -----------------------------------------------------------
// Quest to Talk with Kupole Leda.
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

[QuestScript(90139)]
public class Quest90139Script : QuestScript
{
	protected override void Load()
	{
		SetId(90139);
		SetName("To find another trace");
		SetDescription("Talk with Kupole Leda");

		AddPrerequisite(new LevelPrerequisite(292));
		AddPrerequisite(new CompletedPrerequisite("F_DCAPITAL_20_5_SQ_100"));

		AddReward(new ExpReward(2420348, 2420348));
		AddReward(new ItemReward("expCard13", 3));
		AddReward(new ItemReward("Vis", 12264));

		AddDialogHook("DCAPITAL_20_5_REDA", "BeforeStart", BeforeStart);
		AddDialogHook("DCAPITAL_20_6_REDA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_DCAPITAL_20_5_SQ_110_ST", "F_DCAPITAL_20_5_SQ_110", "When should we start?", "That sounds dangerous"))
		{
			case 1:
				await dialog.Msg("F_DCAPITAL_20_5_SQ_110_AG");
				dialog.HideNPC("DCAPITAL_20_5_REDA");
				await dialog.Msg("FadeOutIN/3000");
				dialog.UnHideNPC("DCAPITAL_20_6_REDA");
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

		await dialog.Msg("F_DCAPITAL_20_5_SQ_110_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

