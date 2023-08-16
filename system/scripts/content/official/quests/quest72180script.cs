//--- Melia Script -----------------------------------------------------------
// Disarming the Defense System (2)
//--- Description -----------------------------------------------------------
// Quest to Talk to Resistance Deputy Commander Kron.
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

[QuestScript(72180)]
public class Quest72180Script : QuestScript
{
	protected override void Load()
	{
		SetId(72180);
		SetName("Disarming the Defense System (2)");
		SetDescription("Talk to Resistance Deputy Commander Kron");

		AddPrerequisite(new CompletedPrerequisite("STARTOWER_88_MQ_70"));
		AddPrerequisite(new LevelPrerequisite(372));

		AddReward(new ExpReward(137754816, 137754816));
		AddReward(new ItemReward("misc_Growth_Reinforce_Tier3", 3));

		AddDialogHook("D_STARTOWER_88_RESISTANCE_SUB_LEADER_KRON_02", "BeforeStart", BeforeStart);
		AddDialogHook("D_STARTOWER_89_RESISTANCE_LEADER_BAYL_01", "BeforeEnd", BeforeEnd);
	}

	private async Task<HookResult> BeforeStart(Dialog dialog)
	{
		var character = dialog.Player;
		if (!character.Quests.Has(this.QuestId))
		{
			switch (await dialog.Select("STARTOWER_88_MQ_80_DLG1", "STARTOWER_88_MQ_80", "I'll see you upstairs.", "It's not time yet."))
			{
				case 1:
					// Func/SCR_STARTOWER_88_MQ_80_START/0;
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
			await dialog.Msg("STARTOWER_88_MQ_80_DLG2");
			return HookResult.Break;
		}

		return HookResult.Continue;
	}
}

