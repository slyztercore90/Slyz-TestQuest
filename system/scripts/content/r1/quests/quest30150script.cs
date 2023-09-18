//--- Melia Script -----------------------------------------------------------
// How to beat stronger foes(2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Zanas' Soul.
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

[QuestScript(30150)]
public class Quest30150Script : QuestScript
{
	protected override void Load()
	{
		SetId(30150);
		SetName("How to beat stronger foes(2)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(259));
		AddPrerequisite(new CompletedPrerequisite("PRISON_78_MQ_5"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 17));
		AddReward(new ItemReward("Vis", 10360));

		AddDialogHook("PRISON_78_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_78_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_78_MQ_6_select", "PRISON_78_MQ_6", "Say that you will inscribe their magi", "Argue that you can go to Mandara now"))
		{
			case 1:
				await dialog.Msg("PRISON_78_MQ_6_agree");
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

		await dialog.Msg("PRISON_78_MQ_6_succ");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

