//--- Melia Script -----------------------------------------------------------
// Reclaim the Camp (1)
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

[QuestScript(50056)]
public class Quest50056Script : QuestScript
{
	protected override void Load()
	{
		SetId(50056);
		SetName("Reclaim the Camp (1)");
		SetDescription("Talk to Royal Army Guard Delus");

		AddPrerequisite(new LevelPrerequisite(204));
		AddPrerequisite(new CompletedPrerequisite("UNDERFORTRESS_66_MQ010"));

		AddReward(new ExpReward(4160742, 4160742));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier2", 24));
		AddReward(new ItemReward("Vis", 7140));

		AddDialogHook("UNDER66_DELLOOS01", "BeforeStart", BeforeStart);
		AddDialogHook("UNDER66_DELLOOS01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("UNDERFORTRESS_66_MQ020_startnpc01", "UNDERFORTRESS_66_MQ020", "Alright, I'll help you", "I can't help you"))
		{
			case 1:
				await dialog.Msg("UNDER_66_MQ020_startnpc02");
				// Func/UNDER66_KINGDOM_GUADIAN_WARDEN;
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

		await dialog.Msg("UNDERFORTRESS_66_MQ020_succ01");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

