//--- Melia Script -----------------------------------------------------------
// The Hidden Magic Circle
//--- Description -----------------------------------------------------------
// Quest to Talk to Elder Ramunas.
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

[QuestScript(80267)]
public class Quest80267Script : QuestScript
{
	protected override void Load()
	{
		SetId(80267);
		SetName("The Hidden Magic Circle");
		SetDescription("Talk to Elder Ramunas");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_07"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));
		AddReward(new ItemReward("Vis", 19032));

		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_08_ST", "F_3CMLAKE_86_MQ_08", "I will search for it", "That's impossible."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_08_AFST");
				// Func/F_3CMLAKE_86_MQ_08_START_RUN;
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

		await dialog.Msg("F_3CMLAKE_86_MQ_08_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

