//--- Melia Script -----------------------------------------------------------
// Zanas' Resolve(2)
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

[QuestScript(30187)]
public class Quest30187Script : QuestScript
{
	protected override void Load()
	{
		SetId(30187);
		SetName("Zanas' Resolve(2)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new LevelPrerequisite(272));
		AddPrerequisite(new CompletedPrerequisite("PRISON_82_MQ_3"));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 18));
		AddReward(new ItemReward("Vis", 11152));

		AddDialogHook("PRISON_82_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_82_OBJ_3", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("PRISON_82_MQ_4_select", "PRISON_82_MQ_4", "Alright", "Say that he should rethink his options"))
		{
			case 1:
				await dialog.Msg("PRISON_82_MQ_4_agree");
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

		// Func/SCR_PRISON_82_MQ_4_SUCC;
		dialog.UnHideNPC("PRISON_82_OBJ_3_AFTER");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

