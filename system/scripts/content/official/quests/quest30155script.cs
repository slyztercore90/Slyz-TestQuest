//--- Melia Script -----------------------------------------------------------
// Another Soul of Zanas(2)
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

[QuestScript(30155)]
public class Quest30155Script : QuestScript
{
	protected override void Load()
	{
		SetId(30155);
		SetName("Another Soul of Zanas(2)");
		SetDescription("Talk to Zanas' Soul");

		AddPrerequisite(new CompletedPrerequisite("PRISON_79_MQ_1"));
		AddPrerequisite(new LevelPrerequisite(262));

		AddReward(new ExpReward(11281842, 11281842));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 171));
		AddReward(new ItemReward("Vis", 10742));

		AddDialogHook("PRISON_79_NPC_1", "BeforeStart", BeforeStart);
		AddDialogHook("PRISON_79_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("PRISON_79_MQ_2_select", "PRISON_79_MQ_2", "I'll go there", "Say that it is nonsense"))
			{
				case 1:
					await dialog.Msg("PRISON_79_MQ_2_agree");
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
			await dialog.Msg("PRISON_79_MQ_2_succ");
			// Func/SCR_PRISON_79_MQ_2_SUCC;
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

