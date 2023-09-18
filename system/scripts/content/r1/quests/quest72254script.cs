//--- Melia Script -----------------------------------------------------------
// Towards the Central Square
//--- Description -----------------------------------------------------------
// Quest to Talk to Neringa.
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

[QuestScript(72254)]
public class Quest72254Script : QuestScript
{
	protected override void Load()
	{
		SetId(72254);
		SetName("Towards the Central Square");
		SetDescription("Talk to Neringa");

		AddPrerequisite(new LevelPrerequisite(441));
		AddPrerequisite(new CompletedPrerequisite("CASTLE102_MQ_06"));

		AddObjective("kill0", "Kill 15 Orc Spearman(s) or Orc Peltast(s) or Orc Shaman(s) or Orc Leader(s)", new KillObjective(15, 59326, 59327, 59356, 59328));

		AddReward(new ExpReward(-2147483648, -2147483648));
		AddReward(new ItemReward("Vis", 26019));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 17));

		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeStart", BeforeStart);
		AddDialogHook("EP12_MAINSTREAM_NERINGA", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("DCAPITAL53_1_MQ_01_DLG01", "DCAPITAL53_1_MQ_01", "Alright", "End conversation"))
		{
			case 1:
				// Func/SCR_QUEST_ATTENDACE_MONGOLOG;
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

		await dialog.Msg("DCAPITAL53_1_MQ_01_DLG03");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

