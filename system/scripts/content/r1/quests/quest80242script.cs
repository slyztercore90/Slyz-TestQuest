//--- Melia Script -----------------------------------------------------------
// Cleaning Up the Lake
//--- Description -----------------------------------------------------------
// Quest to Talk to the Resistance Soldier Mait.
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

[QuestScript(80242)]
public class Quest80242Script : QuestScript
{
	protected override void Load()
	{
		SetId(80242);
		SetName("Cleaning Up the Lake");
		SetDescription("Talk to the Resistance Soldier Mait");

		AddPrerequisite(new LevelPrerequisite(362));

		AddReward(new ExpReward(65948704, 65948704));
		AddReward(new ItemReward("expCard15", 3));
		AddReward(new ItemReward("Vis", 18824));

		AddDialogHook("F_3CMLAKE_85_MQ_01_NPC_2", "BeforeStart", BeforeStart);
		AddDialogHook("F_3CMLAKE_85_MQ_01_NPC_2", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;

		if (!character.Quests.IsPossible(this.QuestId))
			return HookResult.Skip;

		switch (await dialog.Select("F_3CMLAKE_85_MQ_02_1_ST", "F_3CMLAKE_85_MQ_02_1", "I can do it.", "Sorry, I'll have to refuse."))
		{
			case 1:
				await dialog.Msg("F_3CMLAKE_85_MQ_02_1_AFST");
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

		await dialog.Msg("F_3CMLAKE_85_MQ_02_1_SU");
		character.Quests.Complete(this.QuestId);

		return HookResult.Break;
	}
}

