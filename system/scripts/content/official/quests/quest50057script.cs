//--- Melia Script -----------------------------------------------------------
// Reclaim the Camp (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Royal Army Guard Delus.
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

[QuestScript(50057)]
public class Quest50057Script : QuestScript
{
	protected override void Load()
	{
		SetId(50057);
		SetName("Reclaim the Camp (2)");
		SetDescription("Talk to Royal Army Guard Delus");

		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ020"));
		AddPrerequisite(new LevelPrerequisite(204));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("UNDER66_DELLOOS01", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_DELLOOS01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("UNDERFORTRESS_66_MQ030_startnpc01", "UNDERFORTRESS_66_MQ030", "I will go collect the equipment", "I can't help you"))
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
			await dialog.Msg("UNDERFORTRESS_66_MQ030_succ01");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

