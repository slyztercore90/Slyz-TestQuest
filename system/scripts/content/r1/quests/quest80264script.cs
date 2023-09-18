//--- Melia Script -----------------------------------------------------------
// Enemy Ambush (1)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Adjutant Lehon.
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

[QuestScript(80264)]
public class Quest80264Script : QuestScript
{
	protected override void Load()
	{
		SetId(80264);
		SetName("Enemy Ambush (1)");
		SetDescription("Talk to Resistance Adjutant Lehon");

		AddPrerequisite(new LevelPrerequisite(366));
		AddPrerequisite(new CompletedPrerequisite("F_3CMLAKE_86_MQ_04"));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("F_3CMLAKE_86_MQ_03_NPC", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_86_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_86_MQ_05_ST", "F_3CMLAKE_86_MQ_05", "I'll go have a look.", "It's probably nothing."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_86_MQ_05_AFST");
				dialog.HideNPC("F_3CMLAKE_86_MQ_02_NPC");
				dialog.UnHideNPC("F_3CMLAKE_86_MQ_07_NPC");
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

		await dialog.Msg("F_3CMLAKE_86_MQ_05_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

